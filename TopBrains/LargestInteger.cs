using System;
using System.Collections.Generic;
using System.Text;

namespace LargestInteger
{
    public class Question6
    {
        public int LargestInteger(int a, int b, int c)
        {
            if (a > b && a > c) { return a; }
            else if (b > a && b > c) { return b; }
            else return c;
        }
    }


    public class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nInput First Number: ");
            int num1= int.Parse(Console.ReadLine());
            Console.WriteLine("\nInput Second Number: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("\nInput Third Number: ");
            int num3 = int.Parse(Console.ReadLine());

            Question6 c = new Question6();
            Console.WriteLine($"\nLargest Number : {c.LargestInteger(num1, num2, num3)}");
        }
    }
}
