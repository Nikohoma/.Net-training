//using System.Diagnostics;

//Log Formatter - StringBuilder Performance
//You must generate 10,000 log lines and compare performance.
//Requirements:
//•	Build one big string using '+' concatenation
//•	Build the same using StringBuilder
//•	Measure time using Stopwatch
//Task: Print the time taken by both approaches and explain which is faster in code comments.

using System.Diagnostics;
using System.Text;

namespace LogFormatter
{
    public class User
    {
        public static void NoStringBuilder()
        {
            string result = "";
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for(int i =0; i < 10000; i++)
            {
                result += i.ToString();
            }
            sw.Stop();
            Console.WriteLine($"Elapsed time with regular string : {sw.ElapsedMilliseconds} ms.");
        }

        public static void WithStringBuilder()
        {
            StringBuilder result1 = new StringBuilder();
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            for (int i = 0; i < 10000; i++)
            {
                result1.Append(i.ToString());
            }
            sw1.Stop();
            Console.WriteLine($"Elapsed time with String Builder : {sw1.ElapsedMilliseconds} ms.");
        }

        public static void Main(string[] args)
        {
            User.NoStringBuilder();
            User.WithStringBuilder();
        }
    }
}