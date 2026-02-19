// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Channels;

public delegate void Calculation(int a, int b);
public delegate void Notify();


public class MainClass0
{
    public static event Notify OnCalculation;
    // GENERIC METHOD
    public static void Swap<T>(ref T a, ref T b)
    {
        Console.WriteLine($"Before Swap : a = {a} , b = {b}");
        T temp = a;
        a = b;
        b = temp;
        Console.WriteLine($"After Swap : a = {a} , b = {b}");
    }

    // TO CHECK IF THE VALUE IS PASSED BY REFERENCE(ACTUAL)
    public static void Change(ref string s)
    {
        s = "Changed";
    }

    // METHODS FOR DELEGATE
    public static void Add(int a, int b)
    {
        Console.WriteLine($"Addition : {a + b}");
        OnCalculation?.Invoke();
    }
    public static void Subtract(int a, int b)
    {
        Console.WriteLine($"Subtraction : {a - b}");
        OnCalculation?.Invoke();
    }

    public static void Notification()
    {
        Console.WriteLine("Calculation Triggered.");
    }

    // FUNC EXAMPLE
    public static void Filter(int[] input, Func<int, bool> isEven)
    {
        var result = input.Where(isEven);
        foreach (var r in result)
        {
            Console.Write(r + " ");
        }
    }

    public static bool Filter2(int input, Predicate<int> condition)
    {
        if (condition(input))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void ActionEx(int n, Action<int> action)
    {
        action(n);
    }
    public static void ActionEx1(int n, Action<int> action)
    {
        action(n);
    }

    public static void Main(string[] args)
    {
        int num1 = 10; int num2 = 5;
        string input1 = "Hello"; string input2 = "World";
        Swap(ref input1, ref input2);
        string s = "Hello";
        Console.WriteLine("Before = " + s);
        Change(ref s);
        Console.WriteLine("After = " + s);
        Console.WriteLine("\nDelegates");
        OnCalculation += Notification;
        Calculation calc = Add;
        calc(2, 3);
        calc -= Add;  // Remove add from invocation list 
        calc += Subtract; // Add Subtract to invocation list
        calc(2, 3);
        Console.WriteLine("\nPredicate Output");
        int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
        Filter(nums, x => x % 2 == 0);
        Console.WriteLine("\nFunc");
        var output = Filter2(1, x => x > 0);
        Console.WriteLine(output);
        Console.WriteLine("\nAction");
        ActionEx(2, n => Console.WriteLine($"Number : {n}"));
        ActionEx1(2, x => Console.WriteLine($"Square : {x * x}"));

    }
}


// Output
//Before Swap : a = Hello , b = World
//After Swap : a = World , b = Hello
//Before = Hello
//After = Changed

//Delegates
//Addition : 5
//Calculation Triggered.
//Subtraction: -1
//Calculation Triggered.

//Predicate Output
//2 4 6 
//Func
//True

//Action
//Number : 2
//Square: 4