using System;
using System.Collections.Generic;
using System.Text;

namespace ArithmeticExpressions
{
    /// <summary>
    /// Class to perform operations based on the input with exception handling 
    /// </summary>
    public class ArithmeticExpressions
    {
        /// <summary>
        /// Method to return the result based on the input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Arithmetic (string input)
        {
            string[] parts = input.Split(" ");  // breaking input into parts to retreieve numbers and operator
            try
            {
                // Storing the values
                int num1 = int.Parse(parts[0]);
                int num2 = int.Parse(parts[2]);
                string op = parts[1].Trim();

                // Returning the result based on the operator input
                if (op == "+") { int result = num1 + num2; return result.ToString(); }
                else if(op == "-") { int result = num1 - num2; return result.ToString(); }
                else if (op == "*") { int result = num1 * num2; return result.ToString(); }
                else if (op == "/") { int result = num1 / num2; return result.ToString(); }
                else { return $"Error:Unknown Operator"; }  // Exception if operator didnt match

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message); return $"Error Occured: {e.Message}";
                if (e.Message == "Attempted to divide by zero.") { return $"Error:DivideByZero"; }
                else { return $"Error:Invalid number."; }
            }

        }
    }

    /// <summary>
    /// Main class
    /// </summary>
    public class MainClas()
    {
        public static void Main(string[] args)
        {
            ArithmeticExpressions a = new ArithmeticExpressions();  // Instance creation
            Console.WriteLine(a.Arithmetic("2 - 2"));   // Method calling
        }
    }
}
