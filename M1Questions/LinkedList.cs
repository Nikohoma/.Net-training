using System.Collections.Generic;
using System;

// | Method                 | Meaning             |
// | ---------------------- | ------------------- |
// | AddFirst(value)        | Insert at beginning |
// | AddLast(value)         | Insert at end       |
// | AddBefore(node, value) | Insert before node  |
// | AddAfter(node, value)  | Insert after node   |
// | Remove(value)          | Remove by value     |
// | RemoveFirst()          | Remove first        |
// | RemoveLast()           | Remove last         |
// | Find(value)            | Returns node        |


public class Class198
{

    static LinkedList<int> list = new LinkedList<int>();

    public void Add()
    {
        list.AddLast(30);
        list.AddFirst(20);
        list.AddFirst(10);
    }

    public void Get()
    {
        foreach (var l in list)
        {
            Console.Write(l + " ");
        }
    }
    public void AddAfter(int existingValue, int value)
    {
        LinkedListNode<int> node = list.Find(existingValue);
        list.AddAfter(node, value);
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        Class198 c = new Class198();
        c.Add();
        c.AddAfter(20, 25);
        c.Get();
    }
}