using System;                                          // Console
using System.Collections.Generic;                         // List
using System.Threading;                                  // Thread

namespace ItTechGenie.M1.Threads.Q1
{
    public class HitCounter
    {
        private readonly object _gate = new object();      // lock object
        private int _count = 0;                            // shared state

        // ✅ TODO: Student must implement only this method
        public void Increment()
        {
            // TODO: use lock to increment _count safely
            lock (_gate)
            {
                _count++;
            }
        }

        // ✅ TODO: Student must implement only this method
        public int GetValue()
        {
            // TODO: return _count safely
            lock (_gate)
            {
                return _count;
            }
        }
    }

    internal class Program
    {
        static void Main()
        {
            var counter = new HitCounter();                // shared counter

            int threads = 20;                              // number of threads
            int incPerThread = 50000;                      // increments per thread

            var list = new List<Thread>();                 // store threads

            for (int i = 0; i < threads; i++)              // start workers
            {
                var t = new Thread(() =>                   // create thread
                {
                    for (int j = 0; j < incPerThread; j++) // repeat increments
                        counter.Increment();               // shared update
                });

                list.Add(t);                               // track thread
                t.Start();                                 // run
            }

            foreach (var t in list) t.Join();              // wait all

            Console.WriteLine("Expected: " + (threads * incPerThread));
            Console.WriteLine("Actual  : " + counter.GetValue());
        }
    }
}