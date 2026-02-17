// Base product interface
public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }

// 1. Create a generic repository for products
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();

    // TODO: Implement method to add product with validation
    public void AddProduct(T product)
    {
        // Rule: Product ID must be unique
        // Rule: Price must be positive
        // Rule: Name cannot be null or empty
        // Add to collection if validation passes
        if(_products.Any(p=>p.Id == product.Id)) { throw new Exception("Id already present."); }
        if (product.Price < 0) { throw new Exception("Price cannot be negative."); }
        if(string.IsNullOrWhiteSpace(product.Name)) { throw new Exception("Name cannot be empty."); }
        _products.Add(product);
    }

    // TODO: Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        // Should return filtered products
        return _products.Where(predicate);

    }

    // TODO: Calculate total inventory value
    public decimal CalculateTotalValue()
    {
        // Return sum of all product prices
        return _products.Sum(p=>p.Price);
    }
}

// 2. Specialized electronic product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

// 3. Create a discounted product wrapper
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;

    public DiscountedProduct(T product, decimal discountPercentage)
    {
        // TODO: Initialize with validation
        // Discount must be between 0 and 100
        if(product == null) { throw new ArgumentNullException(); }
        if(discountPercentage < 0 || discountPercentage > 100) { throw new Exception("Invalid Discount."); }
        _product = product; _discountPercentage = discountPercentage;
    }

    // TODO: Implement calculated price with discount
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);

    // TODO: Override ToString to show discount details
    public override string ToString()
    {
        return $"ID : {_product.Id} Name : {_product.Name} Price : {_product.Price} Discount : {_discountPercentage} Updated Price : {DiscountedPrice}";
    }
}

// 4. Inventory manager with constraints
public class InventoryManager
{
    // TODO: Create method that accepts any IProduct collection
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        // a) Print all product names and prices
        // b) Find the most expensive product
        // c) Group products by category
        // d) Apply 10% discount to Electronics over $500
        foreach(var p in products)
        {
            Console.WriteLine($"{p.Name} | {p.Price}");
        }
        var mostExpensiveProduct = products.OrderByDescending(p => p.Price).Take(1).Select(p => p.Name).ToString();
        Console.WriteLine($"Most Expensive Product : {mostExpensiveProduct}");
        var groupedByCategory = products.GroupBy(p => p.Category).ToDictionary(g => g.Key, g => g.ToList());
        Console.WriteLine("Grouped by Category :");
        foreach(var g in groupedByCategory)
        {
            Console.WriteLine(g.Key);
            Console.Write("  --");
            foreach(var v in g.Value)
            {
                Console.WriteLine(v.Name +" "+v.Price);
            }
        }
        foreach(var p in products)
        {
            if(products is ElectronicProduct electronic)
            {
                electronic.Price = electronic.Price * 0.9m; 
            }
        }
    }

    // TODO: Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        // Apply priceAdjuster to each product
        // Handle exceptions gracefully
        if (products == null) { throw new Exception("No Products"); }
        
        // Creating new instance and replacing it in products list.
        for(int i =0; i < products.Count; i++)
        {
            var newPrice = priceAdjuster(products[i]);
            var newProduct = new ElectronicProduct()
            {
                Id = products[i].Id,
                Name = products[i].Name,
                Price = products[i].Price
            };
            products[i] = (T)(IProduct)newProduct;
        }
    }
}

// 5. TEST SCENARIO: Your tasks:
// a) Implement all TODO methods with proper error handling
// b) Create a sample inventory with at least 5 products
// c) Demonstrate:
//    - Adding products with validation
//    - Finding products by brand (for electronics)
//    - Applying discounts
//    - Calculating total value before/after discount
//    - Handling a mixed collection of different product types
public class MainClass
{
    public static void Main(string[] args)
    {
        ProductRepository<ElectronicProduct> repo = new ProductRepository<ElectronicProduct>();
        ElectronicProduct p1 = new ElectronicProduct()
        {
            Id = 101,
            Name = "TV",
            Price = 250000,
            WarrantyMonths = 12,
            Brand = "Samsung"
        };
        ElectronicProduct p2 = new ElectronicProduct()
        {
            Id = 102,
            Name = "Laptop",
            Price = 65000,
            WarrantyMonths = 24,
            Brand = "Asus"
        };
        repo.AddProduct(p1);
        repo.AddProduct(p2);

        InventoryManager manager = new InventoryManager();


    }
}