using Question1;
using Question2;


namespace MainClass
{
    public class MainClass
    {
       
        public static void Main(string[] args)
        {
            #region Movie Library
            // Film Library Instance
            FilmLibrary fl = new FilmLibrary();
            // Adding Films to the list via AddFilm Method
            fl.AddFilm(new Film("Interstellar", "Christopher Nolan",2012));
            fl.AddFilm(new Film("Thor: Ragnarok", "Kevin Feige",2018));
            fl.AddFilm(new Film("The Pianist", "Unknown",2008));
            // Retreiving Total No. of films
            Console.WriteLine($"\nTotal Films : {fl.GetTotalFilmCount()}");
            // Removing film
            fl.RemoveFilm("The Pianist");
            // Getting all films from the list
            Console.WriteLine("\nFilm List: "); 
            foreach (var f in fl.GetFilms()) { Console.WriteLine(f.Title); }
            // Searching the list for the match.
            Console.WriteLine("\nSearching Film: "); 
            foreach (var f in fl.SearchFilms("a")) { Console.WriteLine(f.Title); }
            #endregion

            #region Real Estate Listing Management
            Console.WriteLine("\nReal Estate Listing Management Outputs: ");
            RealEstateApp r = new RealEstateApp();
            r.AddListing(new RealEstateListing(1, "2 BHK Flat", "Available to rent", 25000, "Sector-12"));
            r.AddListing(new RealEstateListing(2, "1 BHK Flat", "Available for Sale", 15000000, "Sector-21"));
            r.AddListing(new RealEstateListing(3, "1 RK Flat", "Available to rent", 20000, "Sector-15"));

            r.RemoveListing(3);
            Console.WriteLine("\nUpdate Listing: ");
            RealEstateListing h = new RealEstateListing(3, "2 RK Flat", "Available to rent", 20000, "Sector-15");
            Console.WriteLine("\nAll Listings: ");
            foreach (var l in r.GetListings() ) { Console.WriteLine($"Title : {l.Title}, Description: {l.Description}, Price: {l.Price}, Location: {l.Location}"); }
            Console.WriteLine("\nListing by Location: ");
            foreach (var l in r.GetListingsByLocation("Sector-12") ) { Console.WriteLine($"Title : {l.Title}, Description: {l.Description}, Price: {l.Price}, Location: {l.Location}"); }
            Console.WriteLine("\nListing by Price Range: ");
            foreach (var l in r.GetListingsByPriceRange(12000,20000) ) { Console.WriteLine($"Title : {l.Title}, Description: {l.Description}, Price: {l.Price}, Location: {l.Location}"); }
            #endregion
        
            
        
        }



    }
}