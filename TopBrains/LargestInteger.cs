using System;
using System.Collections.Generic;
using System.Text;

namespace LargestInteger
{
    /// <summary>
    /// Class incorporating the Method to find the Largest Integer among the inputs 
    /// </summary>
    public class Question6
    {
        /// <summary>
        /// Member method to find the largest integer among the inputs.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int LargestInteger(int a, int b, int c)
        {
            if (a > b && a > c) { return a; }         // Case1: a is largest
            else if (b > a && b > c) { return b; }    // Case2: b is largest
            else return c;                            // Case3: c is largest
        }
    }


    public class MainClass
    {
        public static void Main(string[] args)
        {
            // Input from the user
            Console.WriteLine("\nInput First Number: ");
            int num1= int.Parse(Console.ReadLine());
            Console.WriteLine("\nInput Second Number: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("\nInput Third Number: ");
            int num3 = int.Parse(Console.ReadLine());

            // Class Instance
            Question6 c = new Question6();
            // Calling the method
            Console.WriteLine($"\nLargest Number : {c.LargestInteger(num1, num2, num3)}");
        }
    }
}
