//using System.Xml;

//Remove Duplicates - Array Without LINQ
//A device sends duplicate sensor IDs, but the system needs unique IDs only.
//Requirements:
//•	Input an integer array with duplicates
//•	Create a new array with unique values
//•	Do not use LINQ
//Task: Print the unique array in the same order of first appearance.


namespace RemoveDuplicates
{
    public class User
    {
        public static int[] RemoveDuplicates(int[] input)
        {
            List<int> result = new List<int>();
            foreach(var i in input)
            {
                if (result.Contains(i))
                {
                    continue;
                }
                else
                {
                    result.Add(i);
                }
            }
            return result.ToArray();
        }

        public static void Main(string[] args)
        {
            int[] input = [1, 1, 2, 3, 2, 3, 4, 2,5];
            
            var result = User.RemoveDuplicates(input);
            Console.WriteLine(string.Join(",",result));
        }
    }
}