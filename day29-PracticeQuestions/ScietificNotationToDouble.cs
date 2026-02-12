namespace ConvertScientificNotation
{
    public class ScientificNotationConversion
    {
        public double Convert(string s)
        {
            string digits = "1234567890";
            string[] parts = s.Split("E+");
            var result = int.Parse(parts[0]) * Math.Pow(10, int.Parse(parts[1]));
            return result;

        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            ScientificNotationConversion sc = new ScientificNotationConversion();
            Console.WriteLine(sc.Convert("3E+3")); ;
        }
    }
}