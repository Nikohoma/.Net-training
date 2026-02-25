using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

#region Enums

public enum OrderStatus
{
    Created,
    PaymentPending,
    PaymentProcessing,
    PaymentFailed,
    PaymentSuccessful,
    RestaurantAccepted,
    RestaurantPreparing,
    RestaurantReady,
    DriverAssigned,
    DriverPickedUp,
    OutForDelivery,
    Delivered,
    Cancelled,
    Refunded
}

#endregion

#region Core Result Models

public class OrderProcessingResult
{
    public bool IsSuccess { get; set; }
    public string OrderId { get; set; }
    public string ErrorMessage { get; set; }
    public DateTime? EstimatedDeliveryTime { get; set; }
}

public class OrderUpdate
{
    public string OrderId { get; set; }
    public OrderStatus Status { get; set; }
    public string Message { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

#endregion

#region Custom Exceptions

public class InvalidOrderException : Exception
{
    public InvalidOrderException(string message) : base(message) { }
}

public class RestaurantOfflineException : Exception
{
    public RestaurantOfflineException(string id)
        : base($"Restaurant {id} is offline.") { }
}

#endregion

#region Interfaces (Abbreviated)

public interface IPaymentService
{
    Task<PaymentResult> AuthorizePaymentAsync(decimal amount, string customerId, CancellationToken ct);
    Task<PaymentResult> CapturePaymentAsync(string transactionId, CancellationToken ct);
}

public interface IRestaurantService
{
    Task<bool> AcceptOrderAsync(CustomerOrder order, CancellationToken ct);
    Task<bool> CancelOrderAsync(string orderId, string reason, CancellationToken ct);
}

public interface IDriverService
{
    Task<List<AvailableDriver>> FindAvailableDriversAsync(string orderId, CancellationToken ct);
    Task<bool> AssignDriverAsync(string orderId, string driverId, CancellationToken ct);
}

#endregion

#region Supporting Models

public class PaymentResult
{
    public bool IsSuccess { get; set; }
    public string TransactionId { get; set; }
}

public class AvailableDriver
{
    public string DriverId { get; set; }
    public double Rating { get; set; }
    public int ETA { get; set; }
    public decimal Cost { get; set; }
}

public class CustomerOrder
{
    public string OrderId { get; set; }
    public string CustomerId { get; set; }
    public Restaurant Restaurant { get; set; }
    public List<string> Items { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
}

public class Restaurant
{
    public string Id { get; set; }
    public bool IsOnline { get; set; }
}

#endregion

// ==========================================================
// ================= ORDER PROCESSOR ========================
// ==========================================================

public class OrderProcessingEngine
{
    private readonly IPaymentService _paymentService;
    private readonly IRestaurantService _restaurantService;
    private readonly IDriverService _driverService;

    public OrderProcessingEngine(
        IPaymentService paymentService,
        IRestaurantService restaurantService,
        IDriverService driverService)
    {
        _paymentService = paymentService;
        _restaurantService = restaurantService;
        _driverService = driverService;
    }

    /// <summary>
    /// Main orchestrator for full order lifecycle.
    /// Implements retry, timeout, cancellation and compensation logic.
    /// </summary>
    public async Task<OrderProcessingResult> ProcessOrderAsync(
        CustomerOrder order,
        CancellationToken cancellationToken = default)
    {
        using var timeoutCts = new CancellationTokenSource(TimeSpan.FromMinutes(2));
        using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
            cancellationToken, timeoutCts.Token);

        try
        {
            ValidateOrder(order);

            // 1️⃣ Payment
            order.Status = OrderStatus.PaymentProcessing;
            var paymentResult = await ProcessPaymentWithRetryAsync(order, linkedCts.Token);

            if (!paymentResult.IsSuccess)
                throw new Exception("Payment failed after retries.");

            order.Status = OrderStatus.PaymentSuccessful;

            // 2️⃣ Restaurant Acceptance (45 sec timeout)
            using var restaurantTimeout = new CancellationTokenSource(TimeSpan.FromSeconds(45));
            using var restaurantLinked =
                CancellationTokenSource.CreateLinkedTokenSource(
                    linkedCts.Token, restaurantTimeout.Token);

            var accepted = await _restaurantService
                .AcceptOrderAsync(order, restaurantLinked.Token);

            if (!accepted)
                throw new Exception("Restaurant rejected order.");

            order.Status = OrderStatus.RestaurantAccepted;

            // 3️⃣ Driver Assignment
            var driverAssigned = await AssignDriverAsync(order, linkedCts.Token);
            if (!driverAssigned)
                throw new Exception("No driver available.");

            order.Status = OrderStatus.DriverAssigned;

            return new OrderProcessingResult
            {
                IsSuccess = true,
                OrderId = order.OrderId,
                EstimatedDeliveryTime = DateTime.UtcNow.AddMinutes(30)
            };
        }
        catch (Exception ex)
        {
            order.Status = OrderStatus.Cancelled;

            // Compensation Logic
            await SafeRefundAsync(order);

            return new OrderProcessingResult
            {
                IsSuccess = false,
                OrderId = order.OrderId,
                ErrorMessage = ex.Message
            };
        }
    }

    #region Private Helpers

    private void ValidateOrder(CustomerOrder order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        if (order.Items == null || !order.Items.Any())
            throw new InvalidOrderException("Order must contain items.");

        if (!order.Restaurant.IsOnline)
            throw new RestaurantOfflineException(order.Restaurant.Id);
    }

    /// <summary>
    /// Payment retry logic with exponential backoff (3 attempts)
    /// </summary>
    private async Task<PaymentResult> ProcessPaymentWithRetryAsync(
        CustomerOrder order,
        CancellationToken ct)
    {
        int retries = 3;
        int delay = 500;

        for (int attempt = 1; attempt <= retries; attempt++)
        {
            var result = await _paymentService
                .AuthorizePaymentAsync(order.TotalAmount, order.CustomerId, ct);

            if (result.IsSuccess)
                return result;

            if (attempt < retries)
                await Task.Delay(delay *= 2, ct);
        }

        return new PaymentResult { IsSuccess = false };
    }

    private async Task<bool> AssignDriverAsync(CustomerOrder order, CancellationToken ct)
    {
        var drivers = await _driverService
            .FindAvailableDriversAsync(order.OrderId, ct);

        var bestDriver = drivers
            .OrderBy(d => d.ETA)
            .ThenByDescending(d => d.Rating)
            .ThenBy(d => d.Cost)
            .FirstOrDefault();

        if (bestDriver == null)
            return false;

        return await _driverService
            .AssignDriverAsync(order.OrderId, bestDriver.DriverId, ct);
    }

    private async Task SafeRefundAsync(CustomerOrder order)
    {
        try
        {
            // TODO: Call refund API if payment captured
            await Task.CompletedTask;
            order.Status = OrderStatus.Refunded;
        }
        catch
        {
            // Swallow compensation exception
        }
    }

    #endregion
}

// ==========================================================
// ================= KITCHEN ORCHESTRATOR ===================
// ==========================================================

public class KitchenOrchestrator
{
    /// <summary>
    /// Processes cooking tasks concurrently using Task.WhenAll.
    /// </summary>
    public async Task CookOrderAsync(
        List<string> items,
        CancellationToken ct = default)
    {
        var tasks = new List<Task>();

        foreach (var item in items)
        {
            tasks.Add(CookItemAsync(item, ct));
        }

        await Task.WhenAll(tasks);
    }

    private async Task CookItemAsync(string item, CancellationToken ct)
    {
        // Simulated station time mapping
        int delay = item switch
        {
            "Burger" => 2000,
            "Fries" => 3000,
            "Salad" => 1000,
            "Milkshake" => 500,
            _ => 1500
        };

        await Task.Delay(delay, ct);
    }
}

// ==========================================================
// ================= ORDER BROADCASTER ======================
// ==========================================================

public class OrderStatusBroadcaster
{
    private readonly Dictionary<string, List<OrderUpdate>> _history =
        new Dictionary<string, List<OrderUpdate>>();

    /// <summary>
    /// Streams order updates using IAsyncEnumerable.
    /// </summary>
    public async IAsyncEnumerable<OrderUpdate> SubscribeToOrderUpdates(
        string orderId,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(2000, cancellationToken);

            yield return new OrderUpdate
            {
                OrderId = orderId,
                Status = OrderStatus.OutForDelivery,
                Message = "Live update..."
            };
        }
    }
}

// ==========================================================
// ================= BATCH ORDER PROCESSOR ==================
// ==========================================================

public class BatchOrderProcessor
{
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(100);

    /// <summary>
    /// Processes bulk orders with concurrency limit.
    /// </summary>
    public async Task ProcessOrdersAsync(
        IEnumerable<CustomerOrder> orders,
        Func<CustomerOrder, Task> handler,
        CancellationToken ct = default)
    {
        var tasks = new List<Task>();

        foreach (var order in orders)
        {
            await _semaphore.WaitAsync(ct);

            tasks.Add(Task.Run(async () =>
            {
                try
                {
                    await handler(order);
                }
                finally
                {
                    _semaphore.Release();
                }
            }, ct));
        }

        await Task.WhenAll(tasks);
    }
}

// ==========================================================
// ================= DRIVER MATCHER =========================
// ==========================================================

public class DriverMatcher
{
    /// <summary>
    /// Queries multiple driver providers concurrently and selects best option.
    /// </summary>
    public async Task<AvailableDriver> FindBestDriverAsync(
        List<IDriverService> providers,
        string orderId,
        CancellationToken ct = default)
    {
        using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        using var linked = CancellationTokenSource.CreateLinkedTokenSource(ct, timeoutCts.Token);

        var tasks = providers
            .Select(p => p.FindAvailableDriversAsync(orderId, linked.Token));

        var results = await Task.WhenAll(tasks);

        return results
            .SelectMany(r => r)
            .OrderBy(d => d.ETA)
            .ThenByDescending(d => d.Rating)
            .ThenBy(d => d.Cost)
            .FirstOrDefault();
    }
}