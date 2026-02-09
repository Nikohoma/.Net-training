namespace eCommerceCategoryAnalytics
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
    public interface ICategory
    {
        int Id { get; set; }
        string Name { get; set; }
        List<IProduct> Products { get; set; }
    }

    public class Category : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IProduct> Products { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
            Products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            Products.Add(product);
        }
    }

    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

    }

    public interface ICompany
    {
        int Id { get; set; }
        string Name { get; set; }
    }

    public class Company : ICompany
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ICategory> Categories { get; set; }

        public Company(int id, string name)
        {
            Id = id;
            Name = name;
            Categories = new List<ICategory>();
        }

        public void AddCategory(ICategory category)
        {
            Categories.Add(category);
        }

        public string GetTopCategoryNameByProduct()
        {
            var result = Categories.MaxBy(c => c.Products.Count).Name;   // OR Categories.OrderByDescending(c=>c.Products).First().Name;
            return result;
        }

        public List<IProduct> GetTopCategoryBySumOfProductPrice()
        {
            return Categories.MaxBy(c => c.Products.Sum(p => p.Price)).Products;
        }

        public List<IProduct> GetProductsBelongsToMultipleCategory()
        {
            return Categories.SelectMany(c => c.Products).GroupBy(g => g.Id).Where(p => p.Count() > 1).Select(p => p.First()).ToList();
        }

        public List<ICategory> GetCategoriesWithSumOfTheProductPrices()
        {
            return Categories.OrderByDescending(c => c.Products.Sum(s => s.Price)).ToList();
        }

    }
}