// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Reflection;

public class Class1
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void GetDetails()
    {
        Console.WriteLine($"Id : {Id} Name : {Name}");
    }
}


public class MainClass
{
    public static void Main(string[] args)
    {
        Class1 c = new Class1()
        {
            Id = 1,
            Name = "Nikhil"
        };

        Type type = typeof(Class1);
        Console.WriteLine("\nProperties of Class1");
        var props = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var p in props)
        {
            Console.WriteLine(p.Name + " " + p.GetValue(c));
        }

        Console.WriteLine("\nMethods");
        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
        foreach (var m in methods)
        {
            Console.WriteLine(m.Name);
        }

        Console.WriteLine("\nInvoking Method by Name:");
        foreach (var m in methods)
        {
            if (m.Name == "GetDetails")
            {
                m.Invoke(c, null); // null = parameters. If parameters present : m.Invoke(c, new object[] { 5, 10 });
            }
        }

        Console.WriteLine("\nGet all Members");
        var members = type.GetMembers();
        foreach(var m in members)
        {
            Console.WriteLine(m.Name);
        }
    }
}