using System;
using System.Collections.Generic;
using System.Text;

namespace Question9
{
    /// <summary>
    /// Class with all the methods
    /// </summary>
    public class MahiriAlphabetsVowels
    {
        /// <summary>
        /// Method taking user input and calling the relevant functions
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Tasks(string input)
        {
            string[] parts = input.Split(" ");   // Splitting the input into individual words/parts.
            string task1 = RemoveCommonConsonants(parts[0], parts[1]);   // Task1: removing common consonants from the word
            string[] parts1 = task1.Split(" ");
            string task2 = RemoveConsecutiveDuplicate(parts1[0]);
            string task3 = RemoveConsecutiveDuplicate(parts1[1]);
            string words = task2 + " " +task3;
            string result = words;

            return result;
        }

        /// <summary>
        /// Method to remove vowel from the word
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public string RemoveVowels(string word)
        {
            word = word.Trim();
            string vowels = "aeiouAEIOU";
            StringBuilder newWord = new StringBuilder();  // Building new String
            foreach (char c in word)
            {
                if (!vowels.Contains(c))
                {
                    newWord.Append(c);
                }
            }
            
            return newWord.ToString();
        }

        /// <summary>
        /// Member Method taking input of both words. 
        /// Compares and remove all consonants present in first word that also appears in the second word.
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public string RemoveCommonConsonants(string word1, string word2) 
        {
            string w = RemoveVowels(word2);                // Removing vowels from second word since we are only concerned about the consonants.
            StringBuilder newWord = new StringBuilder();
            
            foreach (char c in word1)
            {
                if (!w.Contains(c)) { newWord.Append(c); }
            }
            newWord.Append(" "+word2);
            return newWord.ToString();
        }

        /// <summary>
        /// Method to compare the character at index[i] and index[i+1] of the word.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public string RemoveConsecutiveDuplicate(string word) 
        {
            word = word.ToLower().Trim();
            string newWord = "";            // new String that stores the result
            newWord += word[0];             // always appending first character to avoid index out of bounds issue.
            for (int i = 1; i < word.Length; i++) 
            {
                if (newWord[newWord.Length-1] != word[i])   // comparing last character of the new string with the character of the original word since we are only concern about the consecutive duplicates.
                {
                    newWord += word[i];
                }
            }
            return newWord;
        }


    }

    /// <summary>
    /// Main Class
    /// </summary>
    public class MainClass
    {
        public static void Main(string[] args)
        {
            // Instance Creation
            MahiriAlphabetsVowels w = new MahiriAlphabetsVowels();
            // User Input
            Console.WriteLine("\nEnter two strings seperated by a space: ");
            string input = Console.ReadLine();
            // Calling Method
            Console.WriteLine(w.Tasks(input)); 


        }
    }
}
