namespace InventoryStockManagement
{
    public class Product
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
        public double UnitPrice { get; set; }
        public int CurrentStock { get; set; }
        public int MinimumStockLevel { get; set; }
        public Product()
        {

        }
    }

    public class StockMovement
    {
        private static int _counter = 1;
        public int MovementId { get;  }
        public string ProductCode { get; set; }
        public DateTime MovementDate { get; set; }
        public string MovementType { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }

        public StockMovement()
        {
            MovementId = _counter++;
        }
    }

    public class InventoryManager
    {
        public List<Product> products = new List<Product>();
        public List<StockMovement> stockMovements = new List<StockMovement>();
        public void AddProduct(string code, string name, string category, string supplier, double price, int stock, int minLevel)
        {
            Product product = new Product()
            {
                ProductCode = code,
                ProductName = name,
                Category = category,
                Supplier = supplier,
                UnitPrice = price,
                CurrentStock = stock,
                MinimumStockLevel = minLevel
            };
            products.Add(product);
        }

        public void UpdateStock(string productCode, string movementType, int quantity, string reason)
        {
            foreach (Product p in products)
            {
                if (p.ProductCode == productCode)
                {
                    StockMovement sm = new StockMovement()
                    {
                        ProductCode = productCode,
                        MovementType = movementType,
                        Quantity = quantity,
                        Reason = reason,
                        MovementDate = DateTime.Now.Date
                    };
                    stockMovements.Add(sm);

                    if (movementType.ToLower().Trim() == "in")
                    {
                        p.CurrentStock += quantity;
                        Console.WriteLine("Quantity Updated");
                    }
                    else
                    {
                        p.CurrentStock -= quantity;
                        Console.WriteLine("Quantity Updated");
                    }
                }
            }
            Console.WriteLine("Cannot find the product");

        }

        public Dictionary<string,List<Product>> GroupProductsByCategory()
        {
            return products.GroupBy(p => p.Category).ToDictionary(p => p.Key, p => p.ToList());
        }

        public List<Product> GetLowStockProducts()
        {
            return products.Where(p => p.CurrentStock <= p.MinimumStockLevel ).ToList();
        }

        public Dictionary<string, int> GetStockValueByCategory()
        {
            return products.GroupBy(p => p.Category).ToDictionary(g => g.Key, g=> (int)g.Average(p=>p.UnitPrice));
        }

    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            InventoryManager im = new InventoryManager();
            im.AddProduct("1A", "Battery", "Electronics", "AB Electronics Ltd.", 250, 300, 200);
            im.AddProduct("2A", "Fruits", "Grocery", "Rama Mandi", 150, 400, 100);
            im.AddProduct("1B", "Notebooks", "Stationary", "Goyal Stationary", 450, 100, 300);

            im.UpdateStock("2A", "In", 100, "Added More Fruits");

            foreach(var p in im.GroupProductsByCategory())
            {
                Console.WriteLine($"Product Category : {p.Key}");
                foreach(var v in p.Value)
                {
                    Console.WriteLine($" -- Product Name: {v.ProductName}");
                }
            }

            Console.WriteLine("Low Stock Products");
            foreach (var s in im.GetLowStockProducts())
            {
                Console.WriteLine($"-- {s.ProductName} , Quantity : {s.CurrentStock}");
            }

            Console.WriteLine("Stock Value By Category: ");
            foreach(var s in im.GetStockValueByCategory())
            {
                Console.WriteLine($"Stock Category : {s.Key}, Average Unit Price : {s.Value}");
            }
        }
    }


}