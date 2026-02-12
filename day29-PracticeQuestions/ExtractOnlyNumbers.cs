using System;
using System.Collections.Generic;
using System.Text;

namespace ExtractNumbers
{
    public class ExtractOnlyNumbers
    {
        public int NumbersSum(string s)
        {
            int result = 0;
            string digits = "1234567890";
            foreach(var i in s)
            {
                if (digits.Contains(i))
                {
                    result += (int)i - '0' ;
                }
            }
            return result;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            ExtractOnlyNumbers e = new ExtractOnlyNumbers();
            Console.WriteLine(e.NumbersSum("8 16 32 bits")); ;
        }
    }
}
