using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryDuplicate
{
    public class InventoryDuplicateClass
    {
        public List<string> DetectDuplicates(List<string> input)
        {
            HashSet<string> hs = new HashSet<string>();
            HashSet<string> result = new HashSet<string>();

            foreach(var i in input)
            {
                if (!hs.Add(i))     // if (hs.Add(i)) : returns true if i not present in hs and false if present. 
                {
                    result.Add(i);
                }
            }
            return result.ToList() ;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            List<string> serials = new List<string> { "S1", "S2", "S1", "S3", "S2", "S2" };
            InventoryDuplicateClass idc = new InventoryDuplicateClass();

            foreach(var i in idc.DetectDuplicates(serials))
            {
                Console.Write(i + " ");
            }
        }
    }
}
