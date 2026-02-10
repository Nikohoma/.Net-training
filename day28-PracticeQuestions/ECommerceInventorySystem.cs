using System;
using System.Collections.Generic;
using System.Linq;

public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; set; }
    Category Category { get; }
}

public enum Category
{
    Electronics,
    Clothing,
    Books,
    Groceries
}

// 1. Generic repository
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();

    public void AddProduct(T product)
    {
        if (product == null)
            throw new ArgumentNullException(product.Name);

        if (_products.Any(p => p.Id == product.Id))
            throw new Exception("Product ID must be unique");

        if (product.Price <= 0)
            throw new Exception("Price must be positive");

        if (string.IsNullOrEmpty(product.Name))
            throw new Exception("Name cannot be null or empty");

        _products.Add(product);
    }

    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        return _products.Where(predicate);
    }

    public decimal CalculateTotalValue()
    {
        return _products.Sum(p => p.Price);
    }

    public List<T> GetAll() => _products;
}

// 2. Electronic product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;

    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

// 3. Discount wrapper
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;

    public DiscountedProduct(T product, decimal discountPercentage)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (discountPercentage <= 0 || discountPercentage >= 100)
            throw new ArgumentException("Discount must be between 0 and 100");

        _product = product;
        _discountPercentage = discountPercentage;
    }

    public decimal DiscountedPrice =>
        _product.Price * (1 - _discountPercentage / 100);

    public override string ToString()
    {
        return $"{_product.Name} | Original: {_product.Price} | Discount: {_discountPercentage}% | Final: {DiscountedPrice}";
    }
}

// 4. Inventory Manager
public class InventoryManager
{
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        Console.WriteLine("\n--- Products ---");
        foreach (var product in products)
            Console.WriteLine($"{product.Name} : {product.Price}");

        var expensive = products.OrderByDescending(p => p.Price).FirstOrDefault();
        Console.WriteLine($"\nMost Expensive: {expensive?.Name}");

        Console.WriteLine("\n--- Grouped By Category ---");
        var grouped = products.GroupBy(p => p.Category);
        foreach (var g in grouped)
        {
            Console.WriteLine(g.Key);
            foreach (var p in g)
                Console.WriteLine("  " + p.Name);
        }

        foreach (var p in products)
        {
            if (p.Category == Category.Electronics && p.Price > 500)
                p.Price *= 0.9m;
        }
    }

    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        try
        {
            foreach (var p in products)
                p.Price = priceAdjuster(p);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Price update failed: " + ex.Message);
        }
    }
}

public class Program
{
    static ProductRepository<ElectronicProduct> repo =
        new ProductRepository<ElectronicProduct>();

    static InventoryManager manager = new InventoryManager();

    public static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n===== INVENTORY MENU =====");
            Console.WriteLine("1. Add Electronic Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Find Products by Brand");
            Console.WriteLine("4. Calculate Total Inventory Value");
            Console.WriteLine("5. Apply Discount (Electronics > $500)");
            Console.WriteLine("6. Bulk Price Update (+ amount)");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        AddProductMenu();
                        break;

                    case 2:
                        ViewAllProducts();
                        break;

                    case 3:
                        FindByBrand();
                        break;

                    case 4:
                        Console.WriteLine("Total Value: " +
                            repo.CalculateTotalValue());
                        break;

                    case 5:
                        manager.ProcessProducts(repo.GetAll());
                        Console.WriteLine("Discount applied.");
                        break;

                    case 6:
                        BulkUpdate();
                        break;

                    case 7:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void AddProductMenu()
    {
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.Write("Brand: ");
        string brand = Console.ReadLine();

        repo.AddProduct(new ElectronicProduct
        {
            Id = id,
            Name = name,
            Price = price,
            Brand = brand,
            WarrantyMonths = 12
        });

        Console.WriteLine("Product added successfully.");
    }

    static void ViewAllProducts()
    {
        var products = repo.GetAll();

        if (products.Count == 0)
        {
            Console.WriteLine("No products available.");
            return;
        }

        foreach (var p in products)
        {
            Console.WriteLine(
                $"Id:{p.Id} Name:{p.Name} Price:{p.Price} Brand:{p.Brand}");
        }
    }

    static void FindByBrand()
    {
        Console.Write("Enter brand: ");
        string brand = Console.ReadLine();

        var result = repo.FindProducts(p => p.Brand == brand);

        foreach (var p in result)
            Console.WriteLine($"{p.Name} - {p.Price}");
    }

    static void BulkUpdate()
    {
        Console.Write("Increase price by amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        manager.UpdatePrices(repo.GetAll(), p => p.Price + amount);

        Console.WriteLine("Prices updated.");
    }
}