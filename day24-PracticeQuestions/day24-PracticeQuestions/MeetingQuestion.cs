using System;
using System.Collections.Generic;
using System.Text;

namespace Meeting
{
    public class genericClass<T>
    {
        public T value { get; set; }

        public genericClass(T value)
        {
            this.value = value; 
        }

        public void Details()
        {
            Console.WriteLine($"Value : {value}");
        }

    }

    public class nonGenericClass
    {
        public int id { get; set; }

        public nonGenericClass(int id)
        {
            this.id = id;
        }
        public void Details()
        {
            Console.WriteLine($"Id : {id}");
        }

        public void ReverseString(string s)
        {
            StringBuilder reversed = new StringBuilder();
            for(int i = s.Length - 1; i>=0; i--)
            {
                reversed.Append(s[i]);
            }
            Console.WriteLine($"Reversed String : {reversed}");
        }

        public void Counter(string s)
        {
            SortedDictionary<char, int> counter = new SortedDictionary<char, int>();
            
            for (int i = 0; i <= s.Length-1; i++)
            {
                if (counter.ContainsKey(s[i]))
                {
                    counter[s[i]] += 1;
                }
                else
                {
                    counter.Add(s[i], 1);
                }
            }
            foreach(var s2 in counter)
            {
                Console.WriteLine($"{s2.Key} : {s2.Value}");
            }
        }
    }


    public class MainClass
    {
        public static void Main(string[] args)
        {
            genericClass<string> gc1 = new genericClass<string>("Name");
            gc1.Details();
            genericClass<int> gc2 = new genericClass<int>(1);
            gc2.Details();

            nonGenericClass ngc1 = new nonGenericClass(20);
            ngc1.Details();

            ngc1.ReverseString("Nikhil");
            Console.WriteLine("Counter :");
            ngc1.Counter("Hello");

        }
    }
}


namespace CommonLettersRemove
{
    public class RemoveCommonLettersClass
    {
        public void RemoveCommonLetters(string s1, string s2)
        {
            int count = 0;
            foreach (var s in s2)
            {
                if (s1.Contains(s))
                {
                    count += 1;
                }
            }
            Console.WriteLine($"Output : {s1.Length - count}");
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            RemoveCommonLettersClass rmc = new RemoveCommonLettersClass();
            rmc.RemoveCommonLetters("leetcode", "etco");
        }
    }
}