using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CheckValidCodesIMochaMock
{
    public class ValidCodes
    {
        public List<int> CheckValidity(string[] codes)
        {
            List<int> result = new List<int>();
            foreach(var c in codes)
            {
                if (c.Length >= 3 && Regex.IsMatch(c.Trim(), @"^[0-9].*[A-Za-z]$"))
                {
                    result.Add(1);
                }
                else
                {
                    result.Add(0);
                }
            }
            return result;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            ValidCodes vc = new ValidCodes();
            Console.WriteLine("Enter N :");
            int n = int.Parse(Console.ReadLine());
            string[] input = new string[n];
            for(int i = 0; i< n; i++)
            {
                var code = Console.ReadLine();
                input[i] = code;
            }
            var output = vc.CheckValidity(input);
            foreach(var o in output)
            {
                Console.WriteLine(o);
            }

        }
    }
}
