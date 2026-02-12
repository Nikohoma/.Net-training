using System;
using System.Collections.Generic;
using System.Text;

namespace FrequencyCheck
{
    public class ElementFrequency
    {
        public Dictionary<string,int> Counter(string[] array)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach(var a in array)
            {
                if (result.ContainsKey(a))
                {
                    result[a] += 1;
                }
                else
                {
                    result.Add(a, 1);
                }
            }
            return result;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            string[] arr = ["a", "a", "b", "a","b", "cb"];
            ElementFrequency f = new ElementFrequency();
            foreach(var k in f.Counter(arr))
            {
                Console.WriteLine($"{k.Key} : {k.Value}");
            }
        }
    }
}
