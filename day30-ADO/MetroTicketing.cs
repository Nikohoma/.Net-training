using System;
using System.Collections.Generic;
using System.Text;

namespace MetroTicketing
{
    public class MetroTicketingClass
    {
        public int CountTickets(Queue<(TimeSpan entryTime, string TicketType)> q)
        {
            int count = 0;
            TimeSpan start = new TimeSpan(8, 0, 0);
            TimeSpan end = new TimeSpan(10, 0, 0);

            while (q.Count > 0)
            {
                var popped = q.Dequeue();

                if (popped.TicketType == "Regular" && popped.entryTime >= start && popped.entryTime <= end){
                    count += 1;
                }

            }
            return count;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            MetroTicketingClass mtc = new MetroTicketingClass();
            Queue<(TimeSpan entry, string type)> q = new Queue<(TimeSpan entry, string type)>();
            q.Enqueue((TimeSpan.Parse("7:45"), "Regular"));
            q.Enqueue((TimeSpan.Parse("8:05"), "Regular"));
            q.Enqueue((TimeSpan.Parse("9:27"), "regular"));
            q.Enqueue((TimeSpan.Parse("9:46"), "Regular"));
            Console.WriteLine($"Count : {mtc.CountTickets(q)}");
        }
    }
}
