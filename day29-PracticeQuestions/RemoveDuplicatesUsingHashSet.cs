using System;
using System.Collections.Generic;
using System.Text;

namespace RemoveDuplicatesUsingHashSet
{
    public class RemoveDuplicates
    {
        public HashSet<int> DuplicatesRemove(int[] input)
        {
            HashSet<int> hs = new HashSet<int>(input);
            return hs;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            int[] arr = [1,2,2,3,1,2,34,56,7];
            RemoveDuplicates rd = new RemoveDuplicates();
            foreach (var a in rd.DuplicatesRemove(arr))
            {
                Console.Write(a + " ");
            }
        }
    }
}
