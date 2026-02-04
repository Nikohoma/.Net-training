using System.Runtime.Intrinsics.X86;

namespace MovieTheatreBookingSystem
{
    /// <summary>
    /// MovieScreening class with the properties and Constructor
    /// </summary>
    public class MovieScreening
    {
        public string MovieTitle { get; set; }
        public DateTime ShowTime { get; set; }
        public string ScreenNumber { get; set; }
        public int TotalSeats { get; set; }
        public int BookedSeats { get; set; }
        public double TicketPrice { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MovieScreening()
        {
        }
    }

    /// <summary>
    /// TheatreManager Class incorporating methods and data storage for Screening details.
    /// </summary>
    public class TheatreManager
    {
        public List<MovieScreening> Screenings = new List<MovieScreening>();    // List to store all Screening details of MovieScreening type

        /// <summary>
        /// Method to Add Screening in the Screenings list
        /// </summary>
        /// <param name="title"></param>
        /// <param name="time"></param>
        /// <param name="screen"></param>
        /// <param name="seats"></param>
        /// <param name="price"></param>
        public void AddScreening(string title, DateTime time, string screen, int seats, double price)
        {
            MovieScreening screening = new MovieScreening()
            {
                MovieTitle = title,
                ShowTime = time,
                ScreenNumber = screen,
                TotalSeats = seats,
                TicketPrice = price
            };
            Screenings.Add(screening);
            Console.WriteLine("Screening Added Successfully.");
        }

        /// <summary>
        /// Method to retreive all screenings details from the list.
        /// </summary>
        public void GetScreenings()
        {
            foreach(MovieScreening m in Screenings)
            {
                Console.WriteLine($"Movie : {m.MovieTitle}, Show Time : {m.ShowTime}, Screen : {m.ScreenNumber}, Total Seats : {m.TotalSeats}, Price : {m.TicketPrice}");
            }
        }

        /// <summary>
        /// Method to book tickets based on the input movieTitle, showTime and tickets.
        /// Validate if the input details first.
        /// </summary>
        /// <param name="movieTitle"></param>
        /// <param name="showTime"></param>
        /// <param name="tickets"></param>
        /// <returns>boolean</returns>
        public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
        {
            foreach (MovieScreening ms in Screenings)
            {
                if (ms.MovieTitle == movieTitle && ms.ShowTime == showTime)
                {
                    if (ms.TotalSeats - ms.BookedSeats >= tickets)
                    {
                        ms.BookedSeats += tickets;
                        ms.TotalSeats -= tickets;
                        Console.WriteLine("Tickets booked successfully.");
                        Console.WriteLine($"Movie Name : {ms.MovieTitle}, Date : {ms.ShowTime.ToString("dd-MM-yyyy")}, Time : {ms.ShowTime.TimeOfDay}.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Not enough seats.");
                        return false;
                    }
                }
            }
            Console.WriteLine("No Screening for the given movie.");
            return false;
        }

        /// <summary>
        /// Method to group screenings by the movie title.
        /// </summary>
        /// <returns>Dictionary</returns>
        public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
        {
            return Screenings.GroupBy(s => s.MovieTitle).ToDictionary(s => s.Key, s => s.ToList());   
        }
       

        /// <summary>
        /// Method to retreive screenings based on the seats 
        /// </summary>
        /// <param name="minSeats"></param>
        /// <returns>List</returns>
        public List<MovieScreening> GetAvailableScreening(int minSeats)
        {
            List<MovieScreening> availableScreenings = new List<MovieScreening>();
            foreach (MovieScreening m in Screenings)
            {
                if (m.TotalSeats - m.BookedSeats >= minSeats)
                {
                    availableScreenings.Add(m);
                }
            }
            return availableScreenings;
        }


        /// <summary>
        /// Method to calculate totalRevenue for each screening
        /// </summary>
        /// <returns>double</returns>
        public void CalculateTotalRevenue()
        {
            foreach (var s in GroupScreeningsByMovie())
            {
                double revenue = s.Value.Sum(s => s.BookedSeats * s.TicketPrice);
                Console.WriteLine($"Revenue for {s.Key} : {revenue}");
            }
        }
    }

    /// <summary>
    /// Main Class
    /// </summary>
    public class MainClass
    {
        public static void Main(string[] args)
        {
            // Instance
            TheatreManager tm = new TheatreManager();
            tm.AddScreening("Ballerina", new DateTime(2026, 02, 06, 2, 30, 00), "Screen 1A", 300, 1000);
            tm.AddScreening("John Wick", new DateTime(2026, 02, 06, 5, 30, 00), "Screen 1B", 450, 2500);
            tm.AddScreening("John Wick", new DateTime(2026, 02, 06, 9, 30, 00), "Screen 2B", 450, 2350);
            tm.AddScreening("Atonement", new DateTime(2026, 02, 07, 4, 30, 00), "Screen 1A", 230, 500);

            // Booking Ticket
            tm.BookTickets("John Wick", new DateTime(2026, 02, 06, 5, 30, 00), 3);

            // Grouping Screenings
            Console.WriteLine("Screenings Grouped by Movie");
            foreach(var m in tm.GroupScreeningsByMovie())
            {
                Console.WriteLine("Movie Title : "+m.Key);
                Console.WriteLine("  ---Screenings Details--- ");
                foreach (var v in m.Value)
                {
                    Console.WriteLine($"Screen : {v.ScreenNumber}, Time : {v.ShowTime}, Available Seats : {v.TotalSeats - v.BookedSeats}");
                }
            }


            // All Screening Details
            Console.WriteLine("Screening Details : ");
            tm.GetScreenings();

            // Available Screenings
            Console.WriteLine("Available Screens :");
            foreach (MovieScreening m in tm.GetAvailableScreening(100))
            {
                Console.WriteLine($"Movie : {m.MovieTitle}, Available Seats : {m.TotalSeats - m.BookedSeats}");
            }

            // Total Revenue of each Screening
            Console.WriteLine("Total Revenue : ");
            tm.CalculateTotalRevenue();

        }

    }

}