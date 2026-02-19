// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;

public class Class1
{
    static Dictionary<string, long[]> memberMap = new Dictionary<string, long[]>();

    public static string AddMember(string memberId)
    {
        if (!memberMap.ContainsKey(memberId))
        {
            memberMap[memberId] = new long[] { 0, 0, 0 }; // memberId->fine imposed, fine left, fine paid
            return $"{memberId} ADDED.";
        }
        else
        {
            return $"Cannot find member";
        }
    }

    public static string ImposeFine(string memberId, long amount)
    {
        if (memberMap.ContainsKey(memberId))
        {
            memberMap[memberId][0] += amount;
            memberMap[memberId][1] += amount;
            return $"Fine imposed on {memberId}";
        }
        else
        {
            return $"Cannot find member";
        }
    }

    public static string PayFine(string memberId, long amount)
    {
        if (memberMap.ContainsKey(memberId))
        {
            if (memberMap[memberId][1] >= amount)
            {
                memberMap[memberId][1] -= amount;
                memberMap[memberId][2] += amount;
                return $"Fine paid";
            }
            else
            {
                return $"Amount more than fine";
            }
        }
        else
        {
            return $"Cannot find member";
        }
    }

    public static void getDetails(string memberId)
    {
        if (memberMap.ContainsKey(memberId))
        {
            Console.Write($"{memberId} "); 
            foreach(var k in memberMap[memberId])
            {
                Console.Write(k+" ");
            }
            Console.WriteLine();
        }
    }

    public static void ProcessCommands(int n)
    {
        List<string> inputs = new List<string>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Write cmd...");
            string cmd = Console.ReadLine();
            inputs.Add(cmd);
        }

        foreach (var i in inputs)
        {
            string[] parts = i.Split(" ");
            if (parts[0] == "ADD")
            {
                var result = AddMember(parts[1]);
                Console.WriteLine(result);
            }
            else if (parts[0] == "IMPOSE")
            {
                var result = ImposeFine(parts[1], long.Parse(parts[2]));
                Console.WriteLine(result);
            }
            else if (parts[0] == "PAY")
            {
                var result = PayFine(parts[1], long.Parse(parts[2]));
                Console.WriteLine(result);
            }
            else
            {
                getDetails(parts[1]);
            }
        }
    }
}


public class Mainclass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Class1.ProcessCommands(n);

        // Input:
        // 7 
        // ADD M1 // ADD M2 // IMPOSE M1 500 // IMPOSE M2 500 // PAY M2 200 // DETAILS M1 
        // Output: 
        // M1 500 500 0    fineImposed, fineLeft, finePaid
        // M2 500 300 200
    }
}