namespace LuckyDraw
{
    public class LuckyDraw
    {
        /// <summary>
        /// Method to check if the input number is Prime.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPrime(int n)
        {
            if (n <= 1) return false;

            for (int i = 2; i * i < n; i++)
            {
                if (n % i == 0) { return false; }
            }
            return true;
        }

        /// <summary>
        /// Method to find sum of digits
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int SumOfDigits(int x)
        {
            int sum = 0;
            while (x > 0)
            {
                sum += x % 10;
                x /= 10;
            }
            return sum;
        }

        /// <summary>
        /// Method to check if the number is lucky.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int CheckLuckyDraw(int min, int max)
        {
            List<int> list = new List<int>();
            for (int i=min; i<=max; i++)
            {
                if(!IsPrime(i)) //20
                {
                    int NumberSquare = i * i; //400
                    int NumberSquareSum = SumOfDigits(NumberSquare); //4
                    int s = SumOfDigits(i); //2
                    int sumSquare = s * s; //4
                    if (sumSquare == NumberSquareSum) { list.Add(i); }
                }
            }
            return list.Count;
        }
    }

    /// <summary>
    /// Main Class
    /// </summary>
    public class MainClass
    {
        public static void Main(string[] args)
        {
            LuckyDraw l = new LuckyDraw(); // Instance 
            Console.WriteLine("Total Lucky Numbers : "+l.CheckLuckyDraw(20, 30));
        }
    }
}