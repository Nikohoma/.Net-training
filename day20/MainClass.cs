using System;
using System.Collections.Generic;
using System.Text;
using Attributes;

namespace MainClass
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Calculator c = new Calculator();
            Console.WriteLine(c.OldAdd(2,3));  // Attribute Warning
            Console.WriteLine(c.NewAdd(2,3));
        }
    }
}
