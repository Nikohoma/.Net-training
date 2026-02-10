using System.Text;

namespace HashesToFront
{
    public class Hashes
    {
        public void HashesToFront(string input)
        {
            StringBuilder inputString = new StringBuilder();
            StringBuilder result = new StringBuilder();
            inputString.Append(input);
            foreach (var s in input)
            {
                if (s == '#')
                {
                    result.Append(s);
                    inputString.Replace(s,' ');
                }
            }
            var string1 = inputString.ToString().Trim();
            foreach (var k in string1)
            {
                result.Append(k);
            }
            var output = result.ToString().Replace(" ", "");
            Console.WriteLine($"{output}");
            
        }
    }

    public class User
    {
        public static void Main(string[] args)
        {
            Hashes h = new Hashes();
            h.HashesToFront("N#ik#hi#l");
        }
    }
}