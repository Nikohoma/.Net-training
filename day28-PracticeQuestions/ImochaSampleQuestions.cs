// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;

public class Class1
{
    public static int powerGame(int n, int[] A)
    {
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            if (sum == 0)
            {
                sum += A[i];
            }
            else if (A[i] > sum)
            {
                sum = 0;
            }
            else
            {
                sum += A[i];
            }
        }
        return sum;
    }
    public static string EqualSums(string s)
    {
        int totalSum = 0;
        for (int i = 0; i < s.Length; i++)
        {
            totalSum += s[i] - 'a' + 1;
        }

        int leftSum = s[0] - 'a' + 1;
        for (int i = 1; i < s.Length; i++)
        {
            char c = s[i];
            int currentSum = s[i] - 'a' + 1;
            int rightSum = totalSum - currentSum - leftSum;
            if (leftSum == rightSum) { return c.ToString(); }
            leftSum += currentSum;
        }
        return "-400";
    }
}

public class MainClass
{

    public static void Main(string[] args)
    {
        int n = 5; int[] arr = new int[] { 6, 5, 17, 2, 1 };
        // var output = Class1.powerGame(n,arr);
        // Console.WriteLine(output);
        var output2 = Class1.EqualSums("abbde");
        Console.WriteLine(output2);
    }
}