// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Reflection;
using System.Xml.Linq;

public class Class1
{
    public int Id;
    public string Name { get; set; }
    private decimal _salary;

    public void CustomMethod() { }
}


public class HelloWorld
{
    public static void Main(string[] args)
    {
        Type t = typeof(Class1);
        Console.WriteLine(t);

        Console.WriteLine("\nFields");
        var fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var f in fields)
        {
            Console.WriteLine(f.Name + " : " + f.FieldType.Name);
        }

        Console.WriteLine("\nProperties");
        var props = t.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var p in props)
        {
            Console.WriteLine(p.Name + " : " + p.PropertyType.Name);
        }

        Console.WriteLine("\nMethods");
        var method = t.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        foreach (var m in method)
        {
            Console.WriteLine(m.Name + " : " + m.ReturnType.Name);
        }

        var m1 = t.GetMethod("CustomMethod");
        Console.WriteLine("GetMethod() Return Type : " + m1.ReturnType.Name);
    }
}

// Output
//Class1

//Fields
//Id : Int32
//<Name> k__BackingField : String
//_salary : Decimal

//Properties
//Name : String

//Methods
//get_Name : String
//set_Name : Void
//CustomMethod : Void
//Equals : Boolean
//GetHashCode : Int32
//GetType : Type
//ToString : String
//GetMethod() Return Type : Void