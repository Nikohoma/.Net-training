using System;
using System.Collections.Generic;
using System.Text;

namespace TotalMinutes
{
    public class TimeInMinutes
    {
        public int ConvertTime(string s)
        {
            string[] parts = s.Split(":");
            var num1 = int.Parse(parts[0]) * 60;
            var result = num1 + int.Parse(parts[1]);
            return result;
        }
    }
    public class MainClass
    {
        public static void Main(string[] args)
        {
            TimeInMinutes time = new TimeInMinutes();
            Console.WriteLine(time.ConvertTime("12:30")); ;
        }
    }
}
