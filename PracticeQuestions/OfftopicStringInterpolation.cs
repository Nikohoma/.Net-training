using System;

public class MainClass2
{
    public static void Main(string[] args)
    {
        var num = 12323.456796;
        Console.WriteLine($"{num:E}");
        Console.WriteLine($"{num:C}"); // Currency
        Console.WriteLine($"{num:F2}");
        Console.WriteLine($"{num:N}");  // Thousand representation without decimal
        Console.WriteLine($"{num:N1}");  // with decimal upto 1
    }
}

// Output
//1.232346E+004
//? 12,323.46   Local Currency Symbol
//12323.46
//12,323.46
//12,323.5
