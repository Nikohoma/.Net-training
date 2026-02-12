using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayElementSum
{
    public class ElementSum
    {
        public int elementSum(int[] arr)
        {
            int count = 0;
            foreach (var a in arr)
            {
                count += a;
            }
            return count;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            ElementSum e = new ElementSum();
            int[] input = [1, 2, 3, 4, 5,];
            Console.WriteLine(e.elementSum(input));
        }
    }
}
