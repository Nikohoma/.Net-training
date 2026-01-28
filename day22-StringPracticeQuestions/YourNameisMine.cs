using System;
using System.Collections.Generic;
using System.Text;

namespace YourNameisMine
{
    // Class storing member methods to validate names and find compatibility value
    public class MadeForEachOther
    {
        /// <summary> 
        /// Member method that takes name inputs and check if they are valid. 
        /// If they are valid. Call other methods to check if they are made for each other and to calculate compatibility value.
        /// </summary>
        /// <param name="man"></param>
        /// <param name="woman"></param>
        public void CheckMadeForEachOther(string man, string woman)     
        {
            string num = "1234567890"; // To check if name contains number

            // Validating names (if they contain numbers, invalid.)
            if (man.Contains(num) && woman.Contains(num)) { Console.WriteLine($"{man} and {woman} are invalid names."); return; }
            if (man.Contains(num)) { Console.WriteLine($"{man} is not a vaild name"); return;  }
            if (woman.Contains(num)) { Console.WriteLine($"{woman} is not a vaild name"); return; }

            // Valid names
            bool subSequence = SubSequence(man, woman);  // To check if one name is subsequence of other. If yes, they are made for each other and compatibility value is calculated.
            if (subSequence) 
            { 
                Console.WriteLine($"{man} and {woman} are made for each other");    
                Console.WriteLine($"Compatibility Value: {Math.Abs(man.Length - woman.Length)}");      // Compatibility value calculation.
                return; 
            }
            else
            {
                Console.WriteLine($"{man} and {woman} are not made for each other.");
                return;
            }
        }

        /// <summary>
        /// Member method to check if one name is subsequence of each other.
        /// </summary>
        /// <param name="man"></param>
        /// <param name="woman"></param>
        /// <returns></returns>
        public bool SubSequence(string man, string woman) 
        {
            string shorterName = ShortName(man, woman);  // To check which name is shorter
            int count = 0;

            if (shorterName == man)      
            {
                for (int i = 0; i < man.Length; i++)        
                {
                    for (int j = 0; j < woman.Length; j++)
                    {
                        if (man[i] == woman[j]) { count++; }
                        if (man.Length == count) { return true; }      // break if count equals manName length. Necessary if alphabets are repeated(increases the count)
                    }
                }
                if(count == man.Length) { return true; }       // to check if all the alphabets of man's name are present in woman's name.
                else { return false; }
            }
            else  
            {
                for (int i = 0; i < woman.Length; i++)
                {
                    for (int j =0; j< man.Length; j++)
                    {
                        if (woman[i] == man[j]) { count++; }
                        if (woman.Length == count) { return true; }     // Necessary if alphabets are repeated(increases the count)
                    } 
                }
                if (count == woman.Length) { return true; }    // to check if all the alphabets of woman's name are present in man's name.
                else { return false; }

            }

       
        }

        /// <summary>
        /// Member method to check which name is shorter.
        /// </summary>
        /// <param name="man"></param>
        /// <param name="woman"></param>
        /// <returns></returns>
        public string ShortName(string man, string woman)
        {
            int mCount = 0; int wCount = 0;
            for(int i = 0; i<man.Length; i++)
            {
                mCount += 1;
            }
            for (int i = 0; i < woman.Length; i++)
            {
                wCount += 1;
            }

            if (mCount > wCount) { return woman; }
            else { return man; }

        }
    }

    /// <summary>
    /// Main Class
    /// </summary>
    public class MainClass
    {
        // Entry Point
        public static void Main(string[] args)
        {
            // Instance
            MadeForEachOther c = new MadeForEachOther();
            // User Inputs
            Console.WriteLine("Enter Man Name: ");
            string man = Console.ReadLine();
            Console.WriteLine("Enter Woman Name: ");
            string woman = Console.ReadLine();
            // Calling Method
            c.CheckMadeForEachOther(man, woman);

        }
    }
}
