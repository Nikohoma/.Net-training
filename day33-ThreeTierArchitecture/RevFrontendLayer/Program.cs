using BLReverse;

namespace FRontendLayer
{
    public class MainClass
    {
        public static void Main()
        {
            ReverseBL rev = new ReverseBL();
            var output = rev.ReverseString();
            Console.WriteLine(output) ;
        }
    }
}
