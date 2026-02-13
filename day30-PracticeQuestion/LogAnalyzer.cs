using System;
using System.Collections.Generic;
using System.Text;

namespace LogAnalyzer
{
    public class LogAnalyzerClass
    {
        public string MostFrequent(List<string> input)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach(var i in input)
            {
                if (result.ContainsKey(i))
                {
                    result[i] += 1;
                }
                else
                {
                    result.Add(i, 1);
                }
            }
            return result.OrderByDescending(r => r.Value).ThenBy(r=>r.Key).Select(g=>g.Key).First().ToString();
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            LogAnalyzerClass l = new LogAnalyzerClass();
            Console.WriteLine(l.MostFrequent(new List<string> { "E02", "E01", "E02", "E01", "E03" }));
        }
    }
}
