using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBooking
{
    public class MovieBookingClass
    {
        public List<int> BookSeats(int n, List<int> alreadyBooked, int request)
        {
            SortedSet<int> Seats = new SortedSet<int>();
            for(int i = 1; i < n+1; i++)
            {
                if (alreadyBooked.Contains(i))
                {
                    continue;
                }
                Seats.Add(i);
            }
            return Seats.Take(request).ToList();
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            MovieBookingClass mbc = new MovieBookingClass();
            List<int> booked = new List<int> { 2, 5 };
            foreach (var i in mbc.BookSeats(10, booked, 3))
            {
                Console.Write(i + " ");
            }
        }
    }
}
