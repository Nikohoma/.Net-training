
namespace MiniOrderSystem
{
    /// <summary>
    /// Customer Type
    /// </summary>
    public class Customer
    {
        private static int _counter = 0;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Customer()
        {
            CustomerId = _counter++;
        }
    }

    /// <summary>
    /// Order Type
    /// </summary>
    public class Order
    {
        private static int _counter = 100;
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string DestinationAddress { get; set; }
        public List<string> OrderItem { get; set; }
        public string PaymentReferenceNumber { get; set; }
        public decimal OrderPrice { get; set; }
        public Order()
        {
            OrderId = _counter++;  
        }
    }
    /// <summary>
    /// Product Type
    /// </summary>
    public class Product
    {
        private static int _counter = 1000;
        public int ProductId { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public Product()
        {
            ProductId = _counter++;
        }
    }

    /// <summary>
    /// Payment Type
    /// </summary>
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }

        public Payment()
        {

        }
    }

    /// <summary>
    /// Order System Class with methods
    /// </summary>
    public class OrderSystem
    {
        List<Customer> customers = new List<Customer>();
        List<Order> orders = new List<Order>();
        List<Payment> payments = new List<Payment>();
        List<Product> products = new List<Product>();
        
        /// <summary>
        /// Validates and Adds Customer
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        public void AddCustomer(string name, string address, string phone)
        {
            try
            {
                if (name != null && orders != null && address != null)
                {
                    Customer c = new Customer()
                    {
                        CustomerName = name,
                        Address = address,
                        Phone = phone
                    };
                    customers.Add(c);
                    Console.WriteLine("Customer Added.");
                }
            }
            catch (Exception e) { Console.WriteLine("Check Credentials Again"); }
        }

        /// <summary>
        /// validate input, add into orders list and place Order. 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="address"></param>
        /// <param name="items"></param>
        public void PlaceOrder(int customerId, string address, List<string> items)   
        {
            if (items != null && address != null)
            {
                decimal totalPrice = 0;
                foreach(var i in items)
                {
                    foreach(Product p in products)                                    
                    { 
                        if (p.Name.ToLower().Trim() == i.ToLower().Trim())           
                        {
                            totalPrice += p.Price;               // Calculating total price 
                        }
                    }
                }

                Order o = new Order()                         
                {
                    CustomerId = customerId,
                    DestinationAddress = address,
                    OrderItem = items,
                    OrderPrice = totalPrice,
                    PaymentReferenceNumber = DateTime.Now.ToString("RN123HH456mm789ss")   // Random Number from timestamp 
                };
                orders.Add(o);
                Console.WriteLine("Order Placed.");

            }
            else
            {
                throw new Exception("Items/Address cannot be null.");
            }
        }

        /// <summary>
        /// Adds a new product with the specified name and price to the collection.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public void AddProduct(string name, decimal price)
        {
            if(!string.IsNullOrEmpty(name))
            {
                Product p = new Product()
                {
                    Name = name,
                    Price = price
                };
                products.Add(p);
                Console.WriteLine("Product Added.");
            }
            else
            {
                throw new Exception("Name cannot be empty");
            }
        }

        /// <summary>
        /// Retreive orders of customers
        /// </summary>
        /// <param name="id"></param>
        public void GetOrder(int id)   // id = customerId
        {
            try
            {
                foreach (Order o in orders)
                {
                    if (o.CustomerId == id)
                    {
                        Console.WriteLine($"Order ID : {o.OrderId} , Order Price : {o.OrderPrice}, Reference Number : {o.PaymentReferenceNumber}");
                        Console.WriteLine($"Products in order : ");
                        foreach (var k in o.OrderItem)
                        {
                            Console.WriteLine($" -- {k}");
                        }

                    }
                }
            }
            catch (Exception e) { Console.WriteLine($"Error : {e.Message}"); }
        }

    }

    /// <summary>
    /// Main Class
    /// </summary>
    public class MainClass
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            OrderSystem os = new OrderSystem();   // Instance

            // Adding Products
            Console.WriteLine("Products Adding");
            os.AddProduct("Books", 250);
            os.AddProduct("Pen", 50);
            os.AddProduct("Board", 400);
            os.AddProduct("Bag", 850);

            // Adding Customers
            Console.WriteLine("Adding Customers");
            os.AddCustomer("Nikhil", "New Delhi", "8237423423");
            os.AddCustomer("Harsh", "Noida", "39239423");
            os.AddCustomer("Abhinav", "Gurugram", "984594534");

            // List to store items
            List<string> items = new List<string>();
            items.Add("Pen"); items.Add("Marker"); items.Add("Bag");

            // Placing order
            Console.WriteLine("Placing Order");
            os.PlaceOrder(1, "Jalandhar", items);

            // Retrieving order of customer
            Console.WriteLine("Order of Customer 1");
            os.GetOrder(1);

        }
    }

}
