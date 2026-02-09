//Find Longest Word - String + Loop
//A document tool highlights the longest word in a paragraph.
//Requirements:
//•	Ignore punctuation like . , ! ?
//•	If multiple words tie, return the first occurring
//Task: Input a paragraph and print the longest word.


namespace FindLongestWord
{
    public class User
    {
        public static void LongestWord(string para)
        {
            para = para.Replace("?", " "); 
            para = para.Replace(".", " ");
            para = para.Replace(".", " ");
            para = para.Replace(",", " ");
            para = para.Replace(":", " ");

            int size = 0;
            string word = "";
            string[] parts = para.Split(" ");
            foreach(var p in parts)
            {
                if (p.Length > size)
                {
                    size = p.Length; word = p;
                }
                else { continue; }
            }
            Console.WriteLine($"Longest Word : {word} , Length : {size}");
        }

        public static void Main(string[] args)
        {
            User.LongestWord("Before await: code runs normally.\r\nAt await: method pauses and returns control to its caller.\r\nAfter await: method resumes when the awaited task finishes.");
        }
    }
}