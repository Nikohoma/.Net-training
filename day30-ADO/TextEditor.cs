using System;
using System.Collections.Generic;
using System.Text;

namespace TextEditor
{
    public class TextEditor
    {
        public string Undo(List<string> input)
        {
            Stack<string> stack = new Stack<string>();
            foreach (var i in input)
            {
                string[] parts = i.Split(" ");
                if (parts[0] == "TYPE")
                {
                    stack.Push(parts[1]);
                }
                else
                {
                    if(stack.Count> 0)
                    {
                        stack.Pop();
                    }
                }
            }

            StringBuilder result = new StringBuilder();
            foreach(var s in stack.Reverse())
            {
                result.Append(s);
                result.Append(" ");
            }
            return result.ToString();
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            TextEditor e = new TextEditor();
            List<string> input = new List<string> { "TYPE Hello", "TYPE World", "UNDO", "TYPE CSharp" };
            Console.WriteLine(e.Undo(input));
        }
    }
}
