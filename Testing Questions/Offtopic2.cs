using System;

public class MainClass1
{
    public static void Main(string[] args)
    {
        string s1 = "Hello";
        string s2 = "hello";
        var result = s1.Equals(s2);
        var result1 = s1.Equals(s2, StringComparison.OrdinalIgnoreCase);
        var result2 = s1.CompareTo(s2);  //Lexicographical comparison with lowercase > uppercase
        var result3 = string.Compare(s1, s2, StringComparison.OrdinalIgnoreCase);
        Console.WriteLine(result3);

        // Ascii : 'a' = 97  'A' = 65
        char c = 'j';  // 106 ascii value
        var result4 = (int)c - 'a'; //106 - 97 = 9 
        Console.WriteLine(result4);
        Console.WriteLine(Math.Pow(2, 3)); // 2^3
    }
}

// Output
//0
//9
//8