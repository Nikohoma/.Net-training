using System;
using System.Collections.Generic;
using System.Text;

namespace CheckPalindrome
{
    public class CheckPalindrome
    {
        public bool IsStringPalindrome(string input)
        {
            int l = 0; int h = input.Length - 1;
            while (l < h)
            {
                if (input[l] != input[h])
                {
                    return false;
                }
                l++; h--;
            }
            return true;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            CheckPalindrome cp = new CheckPalindrome();
            var output = cp.IsStringPalindrome("abjba");
            Console.WriteLine(output);
        }
    }
}
