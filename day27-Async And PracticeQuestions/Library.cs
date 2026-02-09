//using System.Diagnostics.Metrics;

//Library - Composition(Has - A Relationship)
//A library stores books along with author information.
//Requirements:
//•	Create class Author : AuthorName, Country.
//•	Create class Book : Title, Price, and an Author object.
//Task: Create 2 books with authors and print in a clean formatted output.


namespace Library
{
    public class Author
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public Author()
        {

        }
    }
    public class Book
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        Author Author { get; set; }

        public Book(Author author)
        {
            Author = author;
        }

        public void Details()
        {
            Console.WriteLine($"Title : {Title}, Price : {Price}, Author : {Author.Name}, {Author.Country}.");
        }
    }

    public class User
    {
        public static void Main(string[] args)
        {
            Author a1 = new Author()
            {
                Name = "Nikhil",
                Country = "India"
            };
            Book b = new Book(a1)
            {
                Title = "Ranaissance",
                Price = 12000
            };

            Author a2 = new Author()
            {
                Name = "Ray",
                Country = "Japan"
            };

            Book b1 = new Book(a2)
            {
                Title = "Art of Forgiveness",
                Price = 1400
            };

            b.Details();
            b1.Details();
        }
    }
}