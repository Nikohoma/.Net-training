using System;
using System.Collections.Generic;
using System.Text;

namespace CartConsolidation
{
    public class SkuQty
    {
        public static Dictionary<string, int> CalculateSKU(List<(string s, int q)> input)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach(var i in input)
            {
                if(i.q > 0)
                {
                    if (result.ContainsKey(i.s))
                    {
                        result[i.s] += i.q;
                    }
                    else
                    {
                        result.Add(i.s,i.q);
                    }
                }
            }
            return result;
        }
    }
    public class MainClass
    {
        public static void Main(string[] args)
        {
            List<(string sku, int qty)> scans = new List<(string sku, int qty)> { ("A101", 2), ("B205", 1), ("A101", 3), ("C111", -1) };
            foreach(var i in SkuQty.CalculateSKU(scans))
            {
                Console.Write(i.Key + ":"+i.Value);
                Console.Write(" ");
            }
        }
    }
}
