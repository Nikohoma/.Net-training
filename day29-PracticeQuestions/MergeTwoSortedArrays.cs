using System;
using System.Collections.Generic;
using System.Text;

namespace MergeTwoSortedArrays
{
    public class MergeSortedArrays
    {
        public int[] MergeArrays(int[] arr1 , int[] arr2)
        {
            int p1 = arr1[0];
            int p2 = arr2[0];

            if (arr1[0] < arr2[0])
            {
                List<int> r = new List<int>(arr1);
                r.AddRange(arr2);
                return r.ToArray();

            }
            else
            {
                List<int> r = new List<int>(arr2);
                r.AddRange(arr1);
                return r.ToArray();
            }
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            int[] input1 = [1, 2, 3, 4, 5];
            int[] input2 = [6, 7, 8, 9];
            MergeSortedArrays msa = new MergeSortedArrays();
            foreach(var p in msa.MergeArrays(input1, input2))
            {
                Console.Write(p+" ");
            }
        }
    }
}
