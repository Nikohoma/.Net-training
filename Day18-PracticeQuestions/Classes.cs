namespace Question1
{
    /// <summary>
    /// Interface acting as a structure for Film Class. Defines the properties Film can have.
    /// </summary>
    public interface IFilm
    {
        string Title { get; set; }
        string Director { get; set; }
        int Year { get; set; }

    }

    /// <summary>
    /// Class Film inheriting the basic structure of the film
    /// </summary>
    public class Film : IFilm
    {
        // Properties
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        // Constructor
        public Film(string Title, string Director, int Year)
        {
            this.Title = Title; this.Director = Director; this.Year = Year;
        }
    }

    /// <summary>
    /// Defines the methods FilmLibrary can have.
    /// </summary>
    public interface IFilmLibrary
    {
        void AddFilm(IFilm film);
        void RemoveFilm(string title);
        List<IFilm> GetFilms();
        List<IFilm> SearchFilms(string query);
        int GetTotalFilmCount();

    }


    /// <summary>
    /// Class to add IFilm objects in the list. Contains operations of the list.
    /// </summary>
    public class FilmLibrary : IFilmLibrary
    {
        private List<IFilm> _films = new List<IFilm>();

        public void AddFilm(IFilm film)
        {
            _films.Add(film);
            Console.WriteLine($"{film.Title} added successfully.");
        }

        /// <summary>
        /// Removes film if input matches with any.
        /// </summary>
        /// <param name="title"></param>
        public void RemoveFilm(string title)
        {
            bool flag = false;
            foreach ( var f in _films) 
            { 
                if (f.Title.ToLower().Trim() == title.ToLower().Trim()) 
                { 
                    
                    _films.Remove(f);
                    Console.WriteLine($"{title} removed successfully."); flag = true; break; 
                }
            }
            if (!flag) { Console.WriteLine($"{title} not found."); }
            
        }

        /// <summary>
        ///  Retreive the IFilm objects from the list
        /// </summary>
        /// <returns></returns>
        public List<IFilm> GetFilms()
        {
            return new List<IFilm>(_films);   // returning copy of original list(safer)
        }
        /// <summary>
        /// To search through the films in the list if any match with the input string.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<IFilm> SearchFilms(string query)
        {
            List<IFilm> result = new List<IFilm>();

            foreach (IFilm f in _films)
            {
                if (f.Title.ToLower().Trim().Contains(query) | f.Director.ToLower().Trim().Contains(query))
                {
                    result.Add(f);
                }
            }
            if (result == null) { Console.WriteLine("No Films Found."); }
            return result;
        }
        /// <summary>
        /// Method to count no. of films in the list
        /// </summary>
        /// <returns></returns>
        public int GetTotalFilmCount() { return _films.Count(); }
    }
}

namespace Question2
{
    /// <summary>
    /// Interface defining the basic structure of listings.
    /// </summary>
    public interface IRealEstateListing
    {
        // Properties
        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        int Price { get; set; }
        string Location { get; set; }

    }

    /// <summary>
    /// Class holding Real Estate Listings. Inheriting the Properties from Interface
    /// </summary>
    public class RealEstateListing : IRealEstateListing
    {
        // Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }

        // Constructor
        public RealEstateListing(int Id, string Title, string Description, int Price, string Location)
        {
            this.Id = Id; this.Title = Title; this.Description = Description; this.Price = Price; this.Location = Location;
        }
    }

    /// <summary>
    /// Class holding the list of all Real Estates and incorporating all the operations that is to be done on the list.
    /// </summary>
    public class RealEstateApp
    {
        private List<IRealEstateListing> _listings = new List<IRealEstateListing>();

        /// <summary>
        /// Method to add new Listings in the list holding all the listings.
        /// </summary>
        /// <param name="l"></param>
        public void AddListing(IRealEstateListing l)
        {
            _listings.Add(l);
            Console.WriteLine("Listing added successfully");
        }

        /// <summary>
        /// Method to search the list and remove the listing matching with the input listing id.
        /// </summary>
        /// <param name="ListingId"></param>
        public void RemoveListing(int ListingId)
        {
            bool flag = false;
            foreach (IRealEstateListing l in _listings)
            {
                if (l.Id == ListingId) { _listings.Remove(l); Console.WriteLine("Listing Removed Successfully."); flag = true; break; }
            }
            if (!flag) { Console.WriteLine("Listing not found."); }
        }

        /// <summary>
        /// MEthod to update Listing parameters of the matching id.
        /// </summary>
        /// <param name="u"></param>
        public void UpdateListing(IRealEstateListing u)
        {
            bool flag = false;
            foreach (IRealEstateListing l in _listings)
            {
                if (l.Id == u.Id) { l.Title = u.Title; l.Description = u.Description; l.Price = u.Price; l.Location = u.Location; Console.WriteLine("Listing Updated Successfully."); flag = true; break;  }
            }
            if (!flag) { Console.WriteLine("Listing not found."); }
        }

        /// <summary>
        /// Method to get all the listings.
        /// </summary>
        /// <returns></returns>
        public List<IRealEstateListing> GetListings() { return new List<IRealEstateListing>(_listings); }  // returning a new copy of listings (safer than returning original)

        /// <summary>
        /// Method to retreive all the listing matching with the input location.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public List<IRealEstateListing> GetListingsByLocation(string location)
        {
            List<IRealEstateListing> result = new List<IRealEstateListing>();

            foreach (var l in _listings)
            {
                if (l.Location.ToLower().Trim() == location.ToLower().Trim())
                {
                    result.Add(l);
                }
            }
            if (result.Count == 0) { Console.WriteLine("No Listings Found"); }
            return result;
        }

        /// <summary>
        /// MEthod to retreive all the listings within the input Price range.
        /// </summary>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <returns></returns>
        public List<IRealEstateListing> GetListingsByPriceRange(int minPrice, int maxPrice)
        {
            List<IRealEstateListing> result = new List<IRealEstateListing>();

            foreach (var l in _listings)
            {
                if (minPrice <= l.Price && l.Price <= maxPrice) { result.Add(l); }
            }
            if (result.Count == 0)
            {
                Console.WriteLine("No Listings Found");
            }
            return result;
        }



    }   
}

