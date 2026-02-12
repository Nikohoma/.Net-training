using System;
using System.Collections.Generic;
using System.Text;
// a surrogate is part of a UTF-16 encoding pair used to represent characters outside the Basic Multilingual Plane (BMP).
//A high surrogate (U+D800 to U+DBFF)
//A low surrogate (U+DC00 to U+DFFF)
// Valid Surrogate pair : HighSurrogate + LowSurrogate

namespace SurrogateFunction
{
    public class IsSurrogate
    {
        public void StringCheckSurrogate(string input)
        {
            foreach(char c in input)
            {
                Console.WriteLine(char.IsSurrogate(c)); 
            }
        }

        public bool CharCheckSurrogate(char c)
        {
            return char.IsSurrogate(c);
        }
        public bool CharCheckHighSurrogate(char c)
        {
            return char.IsHighSurrogate(c);
        }
        public bool CharCheckLowSurrogate(char c)
        {
            return char.IsLowSurrogate(c);
        }

        public bool CheckValidSurrogatePair(string s)
        {
            for(int i = 0; i<s.Length - 1; i++)
            {
                if (char.IsLowSurrogate(s[i]))
                {
                    if (i == 0 || !char.IsHighSurrogate(s[i-1]))
                    {
                        return false;
                    }
                }
                else
                {
                    if(i == s.Length - 1 || !char.IsLowSurrogate(s[i+1]))
                    {
                        return false;
                    }
                }
            }
            return true;
            
        }

    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            string s = "😊";
            IsSurrogate surr = new IsSurrogate();
            surr.StringCheckSurrogate(s);
            char c = '\uD83D';
            Console.WriteLine(surr.CharCheckSurrogate(c));
            Console.WriteLine("High Surrogate? : "+surr.CharCheckHighSurrogate(c));
            Console.WriteLine("Low Surrogate? : "+surr.CharCheckLowSurrogate(c));
            Console.WriteLine("Valid Surrogate Pair ? : "+surr.CheckValidSurrogatePair("Hello"));     // No surrogates (high/low), only normal char 16bit char. therefore, true
            Console.WriteLine("Valid Surrogate Pair ? : "+surr.CheckValidSurrogatePair("\uDC00"));
        }
    }
}
