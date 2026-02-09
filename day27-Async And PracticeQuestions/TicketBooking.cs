//using Library;
//using System.Net.Sockets;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//Ticket Booking - Static Counter + Object Count
//A cinema generates ticket numbers automatically.
//Requirements:
//•	Create class Ticket with static LastTicketNo starting at 1000.
//•	Each new ticket increments the counter and assigns a new number.
//Task: Book N tickets and print each generated ticket number.

namespace TicketBooking
{
    public class Ticket
    {
        private static int _LastTicketNo = 1000;
        public int TicketNo { get; }

        public Ticket()
        {
            TicketNo = _LastTicketNo++;
        }

        public void TicketNumber()
        {
            Console.WriteLine($"Ticket No. : {TicketNo}");
        }
    }

    public class User
    {
        public static void Main(string[] args)
        {
            Ticket t = new Ticket();
            Ticket t1 = new Ticket();

            t.TicketNumber();
            t1.TicketNumber();
        }
    }
}