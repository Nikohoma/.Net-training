using System;
using System.Collections.Generic;
using System.Text;

namespace MuktiplicationTable
{
    /// <summary>
    /// Class having method to calculate Multiplication table
    /// </summary>
    public class MultiplicationTable
    {
        /// <summary>
        /// Method to calculate Multiplication Table
        /// </summary>
        public int[] multiplicationTable(int min, int max)
        {
            int[] result = new int[max];
            for (int i = 1; i<= max; i++)
            {
                int res = min * i;
                result[i-1] = res;
            }
            
            return result;

        }
    }

    /// <summary>
    /// Main Class 
    /// </summary>
    public class MainClass
    {
        public static void Main(string[] args)
        {
            MultiplicationTable m = new MultiplicationTable(); // Instance of the class incorporating the method
            foreach (var l in m.multiplicationTable(3, 5)) { Console.Write(l +" "); } // To Print Values stored in the result list
        }
    }
}
