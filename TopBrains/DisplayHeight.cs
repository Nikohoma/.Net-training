using System;
using System.Collections.Generic;
using System.Text;

namespace Question7
{
    /// <summary>
    /// Class having a method to categorise the height
    /// </summary>
    public class DisplayHeight
    {
        /// <summary>
        /// Member Method to categorise the height in three categories
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public string HeightCategory(int height)
        {
            return height switch            // Switch to categorise height in 3 categories
            {
                < 150 => "Short",
                <= 180 => "Average",
                >= 180 => "Tall"

            };
        }
    }

    /// <summary>
    /// Main Class
    /// </summary>
    public class MainClass
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //User Input
            Console.WriteLine("Enter height in cms: ");
            int height = int.Parse(Console.ReadLine());

            // Instance of the class
            DisplayHeight h = new DisplayHeight();
            Console.WriteLine(h.HeightCategory(height)); // Method calling
        }
    }
}

