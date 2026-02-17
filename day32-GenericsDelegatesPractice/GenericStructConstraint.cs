using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        Console.WriteLine(Sum(new List<int> { 1, 2, 3 }));      // Expected: 6
        Console.WriteLine(Sum(new List<double> { 1.5, 2.5 }));  // Expected: 4.0

        // Console.WriteLine(Sum(new List<string> { "a", "b" })); // ❌ Should not compile (string is not struct)
    }

    // ✅ TODO: Students implement only this function
    public static T Sum<T>(IEnumerable<T> items) where T : struct // T is a value type, doesnt necessarily means it is numeric (eg. DateTime, guid is also struct)
    {
        // TODO: Sum all items and return the sum
        if (items == null) { throw new Exception("List is empty."); }
        dynamic sum = default(T);
        foreach(var it in items) { sum += it; }
        return sum;
    }
}