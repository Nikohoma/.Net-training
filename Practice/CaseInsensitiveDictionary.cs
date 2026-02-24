//Build a dictionary that treats "apple" and "Apple" as same key.

using System;
using System.Collections.Generic;

class WordDictionary
{
    static void Main()
    {
        Dictionary<string, string> meanings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        // TODO: Add words and demonstrate case-insensitive retrieval
        string word = "yaw";
        string word1 = "Yaw";
        string meaning = "verb: to deviate from a straight course, as a ship";
        if (!meanings.ContainsKey(word))
        {
            meanings[word] = meaning;
        }
        if (!meanings.ContainsKey(word))
        {
            meanings[word1] = meaning;
        }

        foreach(var m in meanings)
        {
            Console.WriteLine("Word = "+m.Key +" Meaning = "+m.Value);
        }
    }

}