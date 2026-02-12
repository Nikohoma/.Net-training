using System;
using System.Collections.Generic;
using System.Text;


namespace day29_PracticeQuestions
{
    public class StringReverse
    {
        public void ReverseString(string s)
        {
            StringBuilder result = new StringBuilder();
            for(int i = s.Length - 1; i>=0; i--)
            {
                result.Append(s[i]);
            }
            Console.WriteLine($"Reversed : {result}");
        }
        
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            StringReverse sr = new StringReverse();
            sr.ReverseString("string");
        }
    }
}
