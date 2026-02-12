using System;
using System.Collections.Generic;
using System.Text;

namespace LargestElementInArray
{
    public class largestElement
    {
        public void LargestElement(int[] array)
        {
            int result = array[0];
            for(int i = 1; i<array.Length; i++)
            {
                if (array[i] > result)
                {
                    result = array[i];
                }
            }
            Console.WriteLine($"Largest Element : {result}");
        }
    }
    
    public class MainClass
    {
        public static void Main(string[] args)
        {
            int[] arr = [1, 2, 3,7, 4, 5];
            largestElement le = new largestElement();
            le.LargestElement(arr);

        }
    }
}
