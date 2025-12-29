namespace Classes;
using System;
using System.Net.WebSockets;
using System.Security.Cryptography;

/// <summary>
/// Internal class. accessible only in same assembly.
/// </summary>
class Indexers
{
    private string[] arr = new  string[3];

    // Indexer 
    public string this [int index]
    {
        get
        {
            return arr[index];
        }
        set
        {
            arr[index] = value;
        }
    }

}



public class Student
{
    #region properties
    public int RNo {get; set;}

    public string? Name {get; set;}

    public string? Address {get; private set;}

    // private Dictionary<string, string> Books= new Dictionary<string,string>();
    // private string[] books = new string[2]; // With fixed size, use list for undefined size.

    private List<string> Courses = new List<string>();

    #endregion

    #region Indexer
    // public string this [int index]
    // {
    //     get
    //     {
    //         return books[index];
    //     }

    //     set
    //     {
    //         books[index] = value;
    //     }
    // }

    public string this [int index]
    {
        get
        {
            return Courses[index];
        }

        set
        {
            Courses.Add(value);
        }
    }


    // No set properties can be set using only Constructor.
    // Private set properties can be set inside the class either using constructor or method
    // Method to private set address using Method.

    public void SetAddress(string address)
    {
        Address = address;
    }
    
    #endregion

}


/// Partial Classes

public partial class Student1
{
    #region Properties
    public int ID {get; set;}
    #endregion

    #region Methods

    public void Info()
    {
        System.Console.WriteLine($"Partial Class 1 Id: {ID}");
    }
    #endregion


    #region Constructor
    public Student1(int id)
    {
        ID = id;
    }
    #endregion
}

public partial class Student1
{
    #region Properties
    public string? Name {get; set;}

    #endregion

    #region
    public void Info1()
    {
        System.Console.WriteLine($"Partial Class 2 \n Id: {ID}, Name: {Name}");
    }
    #endregion
}

/// <summary>
/// Static Class
/// </summary>
public static class GeneralUses
{   
    #region declaration (should be static)
    public static int RNo;
    #endregion

    #region Constructor
    static GeneralUses()
    {
        RNo = 1;
    }
    #endregion

    public static void GetRno(){System.Console.WriteLine($"Roll No : {RNo}");}
}

public static class StringExtension
{
    public static int WordLength(this string str)
    {
        return str.Length;
    }


}