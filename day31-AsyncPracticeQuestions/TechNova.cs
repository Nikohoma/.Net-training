namespace TechNova
{
    // Delegate
    public delegate void Notify();
    public abstract class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public Category(string id, string name,decimal price, int qty)
        {
            if (string.IsNullOrWhiteSpace(name)) { throw new Exception("Name cannot be empty."); }
            if (price < 0) { throw new Exception("Price cannot be negative."); }
            Id = id;
            Name = name;
            Price = price;
            Qty = qty;
        }
    }

    public abstract class Electronics : Category
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int WarrantyPeriod { get; set; }
        public double PowerUsage { get; set; }
        public DateTime ManufacturingDate { get; set; }

        public Electronics(string id ,string name, decimal price,int qty,  string brand, string model, int warrantyPeriod, double powerUsage, DateTime manufacturingDate) : base(id,name,price,qty)
        {
            if (warrantyPeriod < 0 ) { throw new Exception("Warranty Period cannot be negative."); }
            Brand = brand;
            Model = model;
            WarrantyPeriod = warrantyPeriod;
            PowerUsage = powerUsage;
            ManufacturingDate = manufacturingDate;
        }
    }

    public class Laptop : Electronics
    {
        public int Ram { get; set; }
        public int Storage { get; set; }

        public Laptop(string id, string name, decimal price, int qty, string brand, string model, int warrantyPeriod, int powerUsage, DateTime manufacturingDate, int ram, int storage) : base(id, name, price,qty,brand,model,warrantyPeriod,powerUsage,manufacturingDate)
        {
            Ram = ram;
            Storage = storage;
        }
    }

    public abstract class Grocery : Category
    {
        public DateTime ExpiryDate { get; set; }
        public double Weight { get; set; }
        public bool isOrganic { get; set; }
        public double StorageTemperature { get; set; }

        public Grocery(string Id, string Name, decimal Price, int Qty, DateTime expiryDate, double weight, bool isOrganic, double storageTemperature) : base(Id, Name, Price, Qty)
        {
            if (weight < 0) { throw new Exception("Weight cannot be negative"); }
            ExpiryDate = expiryDate;
            Weight = weight;
            this.isOrganic = isOrganic;
            StorageTemperature = storageTemperature;
        }
    }

    public class Milk : Grocery
    {
        public Milk(string Id, string Name, decimal Price, int Qty, DateTime expiryDate, double weight, bool isOrganic, double storageTemperature) : base(Id, Name, Price, Qty, expiryDate,weight,isOrganic,storageTemperature)
        {
            if (weight < 0) { throw new Exception("Weight cannot be negative"); }
            ExpiryDate = expiryDate;
            Weight = weight;
            this.isOrganic = isOrganic;
            StorageTemperature = storageTemperature;
        }
    }

    public enum Gender { Men, Women, Unisex }
    public enum Size { S, M, L, XL }


    public abstract class Clothing : Category
    {
        public string FabricType { get; set; }
        public Gender Gender { get; set; }
        public string Color { get; set; }
        public Size Size { get; set; }
        public Clothing(string id, string name, decimal price, int qty, Size size, Gender gender, string fabricType, string color) : base(id, name, price, qty)
        {
            Size = size;
            Gender = gender;
            FabricType = fabricType;
            Color = color;
        }
    }

    public class Jeans : Clothing
    {
        public Jeans(string id, string name, decimal price, int qty, Size size, Gender gender, string fabricType, string color) : base(id, name, price, qty,size,gender,fabricType,color)
        {
        }
    }

    public class Inventory
    {
        // Events
        public event Notify ProductAdded;
        public event Notify GettingProduct;

        private List<Category> _products = new List<Category>();
        public void AddProduct(Category product)
        {
            _products.Add(product);
            ProductAdded?.Invoke();
        }

        public List<Category> GetProduct()
        {
            return _products.AsReadOnly().ToList();
        }

        public List<Electronics> GetElectronics()
        {
            return _products.OfType<Electronics>().ToList();
        }

        public List<T> GetProducts<T>() where T : Category
        {
            GettingProduct?.Invoke();
            return _products.OfType<T>().ToList();
        }
    }

    public class MainClass
    {
        // Methods for Event
        public static void ProductAddedMessage() { Console.WriteLine("Product Added."); }
        public static void GettingProductMessage() { Console.WriteLine("Getting Products...."); }
        public static void Main(string[] args)
        {

            Inventory inventory = new Inventory();
            inventory.ProductAdded += ProductAddedMessage;
            inventory.GettingProduct += GettingProductMessage;
            Laptop l = new Laptop("1", "Asus Tuf", 80000,100,"Asus", "Tuf", 24, 400, DateTime.ParseExact("21-12-2026","dd-MM-yyyy",null), 16, 1);
            inventory.AddProduct(l);
            foreach(var i in inventory.GetProducts<Laptop>())
            {
                Console.WriteLine(i.Id +" "+ i.Brand +" "+ i.Model +" "+ i.Price);
            }
            Console.WriteLine("Jeans :");
            Jeans j = new Jeans("J101", "Regular Fit", 1000, 250, Size.L, Gender.Men, "Linen", "Beige");
            inventory.AddProduct(j);
            ;
            foreach (var i in inventory.GetProducts<Clothing>())
            {
                Console.WriteLine(i.Id + " "+i.Name+ " " + i.Price);
            }
        }
    }
}