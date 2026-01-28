using System;
using System.Collections.Generic;

#region Helpers

class MinHeap
{
    private PriorityQueue<long, long> pq = new PriorityQueue<long, long>();
    public int Count => pq.Count;
    public void Push(long x) => pq.Enqueue(x, x);
    public long Pop() => pq.Dequeue();
    public long Peek() => pq.Peek();
}

class ReservoirP95
{
    private long[] sample = new long[100_000];
    private long seen = 0;
    private Random rnd = new Random(1);

    public void Add(long v)
    {
        seen++;
        if (seen <= sample.Length)
            sample[seen - 1] = v;
        else
        {
            long j = rnd.NextInt64(seen);
            if (j < sample.Length)
                sample[j] = v;
        }
    }

    public long Value()
    {
        int n = (int)Math.Min(seen, sample.Length);
        if (n == 0) return 0;
        Array.Sort(sample, 0, n);
        return sample[(int)(0.95 * (n - 1))];
    }
}

#endregion

#region Gate

class Gate
{
    public int Id;
    public int Queue;
    public int MaxQueue;
    public long TotalWait;
    public long Count;
    public MinHeap Scanners = new MinHeap();
    public ReservoirP95 P95 = new ReservoirP95();

    public Gate(int id, int scanners)
    {
        Id = id;
        for (int i = 0; i < scanners; i++)
            Scanners.Push(0);
    }
}

#endregion

#region Simulator

class Simulator
{
    Gate[] gates;
    PriorityQueue<int, (int q, int id)> gatePQ;

    public Simulator(int g, int[] scanners)
    {
        gates = new Gate[g];
        gatePQ = new PriorityQueue<int, (int, int)>();

        for (int i = 0; i < g; i++)
        {
            gates[i] = new Gate(i, scanners[i]);
            gatePQ.Enqueue(i, (0, i));
        }
    }

    public void Arrival(long time, long service)
    {
        int gid = gatePQ.Dequeue();
        Gate g = gates[gid];

        while (g.Scanners.Count > 0 && g.Scanners.Peek() <= time)
        {
            g.Scanners.Pop();
            g.Queue--;
        }

        long start = g.Scanners.Count == 0 ? time : Math.Max(time, g.Scanners.Peek());
        long wait = start - time;

        g.TotalWait += wait;
        g.P95.Add(wait);
        g.Count++;

        g.Queue++;
        g.MaxQueue = Math.Max(g.MaxQueue, g.Queue);
        g.Scanners.Push(start + service);

        gatePQ.Enqueue(gid, (g.Queue, gid));
    }

    public void PrintStats()
    {
        Console.WriteLine("\n--- Gate Metrics ---");
        foreach (var g in gates)
        {
            long avg = g.Count == 0 ? 0 : g.TotalWait / g.Count;
            Console.WriteLine(
                $"G{g.Id + 1}  maxQ={g.MaxQueue}  avgWait={avg}  p95={g.P95.Value()}"
            );
        }
    }
}

#endregion

#region Program (MENU)

class Program
{
    static void Main()
    {
        int G = 0;
        int[] scanners = null;
        Simulator sim = null;

        while (true)
        {
            Console.WriteLine("\n===== CHECK-IN SIMULATOR =====");
            Console.WriteLine("1. Initialize Gates");
            Console.WriteLine("2. Run Simulation");
            Console.WriteLine("3. Show Metrics");
            Console.WriteLine("4. Exit");
            Console.Write("Choice: ");

            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    Console.Write("Enter number of gates: ");
                    G = int.Parse(Console.ReadLine());
                    scanners = new int[G];

                    for (int i = 0; i < G; i++)
                    {
                        Console.Write($"Scanners at Gate {i + 1}: ");
                        scanners[i] = int.Parse(Console.ReadLine());
                    }

                    sim = new Simulator(G, scanners);
                    Console.WriteLine("Initialized.");
                    break;

                case 2:
                    if (sim == null)
                    {
                        Console.WriteLine("Initialize first!");
                        break;
                    }

                    Console.Write("Number of arrivals: ");
                    int A = int.Parse(Console.ReadLine());

                    for (int i = 0; i < A; i++)
                    {
                        Console.Write("arrival lookup bag: ");
                        var p = Console.ReadLine().Split();
                        long t = long.Parse(p[0]);
                        long s = long.Parse(p[1]) + long.Parse(p[2]);
                        sim.Arrival(t, s);
                    }

                    Console.WriteLine("Simulation completed.");
                    break;

                case 3:
                    sim?.PrintStats();
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

#endregion
