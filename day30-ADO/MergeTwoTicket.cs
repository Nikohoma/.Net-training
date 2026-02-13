using System;
using System.Collections.Generic;
using System.Text;

namespace MergeTwoTicket
{
    public class MergeTwoTicketClass
    {
        public List<int> merged (List<int> a, List<int> b)
        {
            List<int> result = new List<int>();
            int i = 0; int j = 0; 
            while(i < a.Count() && j < b.Count())
            {
                if (a[i] < b[j])
                {
                    result.Add(a[i]);
                    i++;
                }
                else
                {
                    result.Add(b[j]);
                    j++;
                }
                
            }

            while(i<a.Count) { result.Add(a[i]); i++; }
            while(j<b.Count) { result.Add(b[j]); j++; }
            return result;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            MergeTwoTicketClass m = new MergeTwoTicketClass();
            List<int> a = new List<int> { 1, 4, 7 };
            List<int> b = new List<int> { 2, 3, 8 };

            foreach(var k in m.merged(a, b))
            {
                Console.Write(k + " ");
            }
        }
    }
}
