using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MainClass67
{
    public static void Main()
    {
        int[] arr = new int[] { 1, 2, 3, 1, 3, 2, 3, 4, 2, };
        HashSet<int> hs = new HashSet<int>(arr);
        foreach (var h in hs)
        {
            Console.Write(h + " ");
        }
        Console.WriteLine("\nStack");
        RemoveDuplis(arr);
    }

    public static void RemoveDuplis(int[] arr)
    {
        Stack<int> myStack = new Stack<int>();
        foreach (var a in arr)
        {
            if (!myStack.Contains(a))
            {
                myStack.Push(a);
            }
        }
        foreach (var s in myStack.Reverse())
        { //reverse from linq
            Console.Write(s + " ");
        }
        Console.WriteLine("\nQueue");
        Queue<int> q = new Queue<int>();
        foreach (var a in arr)
        {
            if (!q.Contains(a))
            {
                q.Enqueue(a);
            }
        }
        while (q.Count > 0)
        {
            var num = q.Dequeue();
            Console.Write(num + " ");
        }
    }
}

// Output
//1 2 3 4
//Stack
//1 2 3 4 
//Queue
//1 2 3 4 