using System;                                          // Console
using System.Threading;                                  // Interlocked

namespace ItTechGenie.M1.Threads.Q2
{
    public class Stock
    {
        private int _available;                            // shared stock

        public Stock(int initial) => _available = initial; // constructor

        public int Available => _available;                // read current (non-atomic ok for display)

        // ✅ TODO: Student must implement only this method
        public bool TryPurchase(int qty)
        {
            // TODO:
            // - validate qty > 0
            // - use CompareExchange loop:
            //   read current, compute next, ensure >=0, CAS update
            if (qty < 0) { throw new Exception("Quantity cannot be negative."); }

        }
    }

    internal class AtomicStockUpdate
    {
        static void Main()
        {
            var stock = new Stock(1000);                   // initial stock

            int success = 0;                               // count success
            int fail = 0;                                  // count fail

            // create multiple purchase threads
            Thread t1 = new Thread(() => { if (stock.TryPurchase(3)) Interlocked.Increment(ref success); else Interlocked.Increment(ref fail); });
            Thread t2 = new Thread(() => { if (stock.TryPurchase(999)) Interlocked.Increment(ref success); else Interlocked.Increment(ref fail); });
            Thread t3 = new Thread(() => { if (stock.TryPurchase(2)) Interlocked.Increment(ref success); else Interlocked.Increment(ref fail); });

            t1.Start(); t2.Start(); t3.Start();            // run
            t1.Join(); t2.Join(); t3.Join();               // wait

            Console.WriteLine($"Success={success}, Fail={fail}, Remaining={stock.Available}");
        }
    }
}