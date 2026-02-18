using System;

public class MainClass
{
    public static void Main(string[] args)
    {
        string a = "Hello α/β ✅";
        string b = new String("Hello α/β ✅");

        Console.WriteLine(a == b);
        Console.WriteLine(a.Equals(b));
        Console.WriteLine(object.ReferenceEquals(a, b));
        b = string.Intern(b);
        Console.WriteLine(object.ReferenceEquals(a, b));
    }
}