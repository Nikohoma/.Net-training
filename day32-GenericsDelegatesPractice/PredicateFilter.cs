using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var nums = new List<int> { 2, 5, 8, 11, 14 };

        var evens = Filter(nums, n => n % 2 == 0);
        Console.WriteLine(string.Join(",", evens));         // Expected: 2,8,14

        var big = Filter(nums, n => n >= 10);
        Console.WriteLine(string.Join(",", big));           // Expected: 11,14
    }

    // ✅ TODO: Students implement only this function
    public static List<T> Filter<T>(List<T> items, Predicate<T> match)
    {
        // TODO: return a new list with matched items
        var result = new List<T>(items.Where(num=>match(num)));  // Where expects only Fun<T,bool> : Where(Func). For predicate, wrap it.
        return result;
    }
}