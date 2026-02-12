using System;
using System.Collections.Generic;
using System.Text;

namespace HexToInt
{
    public class HextoInt
    {
        public int ConvertHex(string input)
        {
            int result = 0;
            int count = 0;
            for(int i = input.Length-1; i>=0; i--)
            {
                if (input[i] == 'x')
                {
                    break;
                }
                
                result += (int)Math.Pow(16,count) * ((int)input[i] - 'A' + 10);
                count++;

            }
            return result;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            string num = "0xFF";
            HextoInt hx = new HextoInt();
            Console.WriteLine(hx.ConvertHex(num));

        }
    }
}
