using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PracticeQuestions
{
    public class Parse
    {
        public static void Main()
        {
            Class189 c = new Class189();
            c.Parsing();
        }
    }
    
    public class Class189
    {
        public void Parsing()
        {
            var date = DateTime.Parse("12-01-2025 08:20:12");
            Console.WriteLine(date);

            string input = "12.34";
            int.TryParse(input, out int result);  // if true, store value in result else stores 0.
            Console.WriteLine(result);

            string ip = "192.168.0.1";
            bool isValid = IPAddress.TryParse(ip, out _);
            Console.WriteLine(isValid);
        }
    }
}
