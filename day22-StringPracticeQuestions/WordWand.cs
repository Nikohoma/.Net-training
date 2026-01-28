using System;
using System.Text;

namespace WordWand;

/// <summary>
/// Class storing member methods
/// </summary>
public class Sorcerer
{
    /// <summary>
    /// Method taking string inputs and breaking them into string array of words. 
    /// Also calls other method which operates on the string array.
    /// </summary>
    /// <param name="s1"></param>
    public void WordWand(string s1) 
    {
        string[] parts = s1.Split(" ");

        int NumberOfWords = 0;
        foreach (var w in parts)
        {
            NumberOfWords++;
        }

        if (NumberOfWords % 2 != 0)  // If number of words odd, call ReverseWords()
        { 
            string res = ReverseWords(parts);
            Console.WriteLine($"Word Count : {NumberOfWords}");  
            Console.WriteLine(res); 
        }
        else  // If number of words even, call ReversePosition() 
        { 
            string res = ReversePosition(parts); 
            Console.WriteLine($"Word Count : {NumberOfWords}"); 
            Console.WriteLine(res); 
        }  

    }

    /// <summary>
    /// Member method that reverses each word present in the string array and joins each word into a single string using String Builder
    /// returns a new string 
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string ReverseWords(string[] s)
    {
        StringBuilder newWord = new StringBuilder();
        foreach (var s1 in s)
        {
            for (int i = s1.Length - 1; i >= 0; i--)
            {
                newWord.Append(s1[i]);
            }
            newWord.Append(" ");
        }
        return newWord.ToString();
    }

    /// <summary>
    /// Member method to reverese the position of the words of string array and stores them into a new string.
    /// Returns a new string.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public string ReversePosition(string[] s)
    {
        StringBuilder newWord = new StringBuilder();

        foreach (var s1 in s.Reverse())
        {
            newWord.Append(s1.ToString());
            newWord.Append(" ");
        }
        return newWord.ToString();
    }
}

/// <summary>
/// Main Class
/// </summary>
public class MainClass
{
    // Entry Point
    public static void Main(String[] args)
    {
        Sorcerer s = new Sorcerer();   // Class Instance
        // User Inputs
        Console.WriteLine("Input Sentence: ");
        string sentence = Console.ReadLine();

        s.WordWand(sentence);  // Calling Method
    }
}