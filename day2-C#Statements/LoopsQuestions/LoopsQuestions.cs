using System;
using System.Numerics;

namespace LoopsAndJumpsQuestions;

public class Program
{   

    // Method to print Fibonacci sum
    static int Fib(int n)
    {
        try {
            if (n == 0) {return 0;}
            if (n == 1) {return 1;}

            return Fib(n-1) + Fib(n-2);
        }
        catch
        {
            Console.WriteLine("Caught an Error: ");
            return -1;
        }
    }

    // Method to Print Fibonacci Series upto n
    static List<int> FibSeries(int n)
    {
        try {
        //Region 
            List<int> fibSeries =  new List<int>();
            int a = 0, b =1 ;
            //EndRegion

            while (a <= n)
            {
                fibSeries.Add(a);
                int temp = a + b;
                a = b;
                b = temp;
            }
            return fibSeries;
        }

        catch (Exception e)
        {
            Console.WriteLine("Encountered an Error: "+ e.Message);
            return new List<int>();
        }
    }
    

    // Method to check if the number is Prime.
    static bool IsPrime(int n)
    {
        try {
            if (n <=1) return false;
            if (n == 2) return true;

            for (int i = 2; i * i <= n ; i += 2) {if(n % i == 0) return false;}
            return true;
        }
        catch(Exception e)
        {
            Console.WriteLine("Encountered an Error: "+e.Message);
            return false;
        }
    }


    //Method to check If the number is a Armstrong
    static bool isArmstrong(int n)
    {
        try {
            int originalnum = n ;
            int leng = n.ToString().Length;
            int sum = 0;

            while (n > 0)
            {
                int digit = n % 10;
                sum += (int)Math.Pow(digit,leng);
                n /= 10;
            }
            return sum == originalnum;
        }
        catch (Exception e)
        {
            Console.WriteLine("Encountered the error: "+ e.Message);
            return false;
        }
    }


    // Method to check if the number is Palindrome.
    static bool IsPalindrome(int n)
    {
        try {
            int original = n;
            int reversed = 0, digits = 0;

            while (n > 0)
            {
                digits = n % 10;
                reversed = reversed * 10 + digits;
                n/= 10;
            }
            return original == reversed;
        }
        catch (Exception e)
        {
            Console.WriteLine("Encountered the error: "+e.Message);
            return false;
        }
    }

    // Method to check GCD
    static int GCD(int a,int b)
    {
        try
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }
        catch(Exception e) {Console.WriteLine("Encountered an error while finding GCD."+ e.Message); return -1;}
    }

    //Method to check LCM
    static int LCM (int a, int b)
    {
        try
        {
            return Math.Abs(a*b)/GCD(a,b);
        }
        catch(Exception e ) {Console.WriteLine("Encountered the error: "+ e.Message); return -1;}
    }

    // Method to print pascal's Triangle
    static void PrintPascalsTriangle(int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int s = 0; s < n - i - 1; s++)
                Console.Write(" ");

            long value = 1;

            for (int j = 0; j <= i; j++)
            {
                Console.Write(value + " ");
                value = value * (i - j) / (j + 1);
            }

            Console.WriteLine();
        }
    }


    // Method to convert Binary number to Decimal
    static int BinaryToDecimal(string binary)
    {
        int res = 0;
        int pow = 1;

        for (int i = binary.Length - 1; i >= 0; i--)
        {
            int bit = binary[i] - '0';

            if (bit != 0 && bit != 1)
                Console.WriteLine("Invalid binary number");
                

            res += bit * pow;
            pow *= 2;
        }

        return res;
    }


    // Method to print diamond shape
    static void Diamond(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int s = 1; s <= n - i; s++)
                Console.Write(" ");

            for (int j = 1; j <= (2 * i - 1); j++)
                Console.Write("*");

            Console.WriteLine();
        }

        for (int i = n - 1; i >= 1; i--)
        {
            for (int s = 1; s <= n - i; s++)
                Console.Write(" ");

            for (int j = 1; j <= (2 * i - 1); j++)
                Console.Write("*");

            Console.WriteLine();
        }
    }


    // Method to calculate Factorial
    static BigInteger Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentException("Factorial is not defined for negative numbers");

        BigInteger result = 1;

        for (int i = 1; i <= n; i++)
            result *= i;

        return result;
    }


    // Guess a secret number
    static void Guessgame()
    {
        Random rand = new Random();
        int secret = rand.Next(1, 11);
        int guess;

        Console.WriteLine("Guess the number (b/w 1 to 10):");

        do
        {
            while (!int.TryParse(Console.ReadLine(), out guess))
            {
                Console.WriteLine("Invalid input. Enter a number (b/w 1 to 10):");
            }

            if (guess < secret)
                Console.WriteLine("Guess a larger number.");
            else if (guess > secret)
                Console.WriteLine("Guess a smaller number.");
            else
                Console.WriteLine("Bingo!");

        } while (guess != secret);
    }

    
    //Digital Root
    static int DigitalRoot(int n)
    { try {

            while (n >= 10)
            {
                int sum = 0;
                int temp = n;

                while (temp > 0)
                {
                    sum += temp % 10;
                    temp /= 10;
                }

                n = sum;
            }

            return n;
    } catch (Exception e) {Console.WriteLine("Error Encountered: "+e.Message); return -1;}
    }


    // Skip multiples of 3
    static void Skip3multiples()
    {
        for (int i = 1; i <= 50; i++)
        {
            if (i % 3 == 0)
                continue;

            Console.WriteLine(i);
        }
    }

    
    // Console Menu
    static void ConsoleMenu()
    {
        int choice;

        do
        {
            Console.WriteLine("\n*****MENU******");
            Console.WriteLine("1. Hello");
            Console.WriteLine("2. Print Random Number");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.WriteLine("Enter your choice: ");
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Hello!");
                    break;

                case 2:
                    Console.WriteLine("Random Number b/w 1 and 199: " + new Random().Next(1, 101));
                    break;

                case 3:
                    Console.WriteLine("Exited");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (choice != 3);
    }


    // Check if a number is a strong number 
    static bool IsStrongNumber(int n)
    {
        if (n < 0)
            return false;

        int original = n;
        int sum = 0;

        while (n > 0)
        {
            int digit = n % 10;

            int fact = 1;
            for (int i = 1; i <= digit; i++)
                fact *= i;

            sum += fact;
            n /= 10;
        }

        return sum == original;
    }


    // Deep nested Search
    static void DeepNestedSearch(int search)
    {

        for (int i=0; i<=5 ; i++)
        {
            for (int j =0; j<=5; j++)
            {
                for (int k=0; k <=5; k++)
                {
                    if (i+j+k == search) {goto Exit;}
                }
            }
        }
        Exit: Console.WriteLine("Match Found.");
    }



    // Main class
    static void Main()
    {   

        #region 

        // try {
        //     int num;
        //     string? number;
        //     Console.WriteLine("Enter the number : ");
        //     number = Console.ReadLine();
        //     int.TryParse(number, out num);
        // }
        // catch(Exception e){Console.WriteLine("Encounterd the error: "+e.Message);}

        #endregion

        #region 

        // Fibonacci Sum
        // try{
        // Console.WriteLine(Fib(num)); 
        // } catch (Exception e) {Console.WriteLine("Encountered the error: "+ e.Message);}

        // // Fibonacci Series
        // try {
        // var fib = FibSeries(num);
        // foreach (var x in fib) {Console.Write(x + " ");}
        // } catch (Exception e){Console.WriteLine("Encountered the Error: "+ e.Message);}



        // // Check Prime Number
        // try {
        // if (IsPrime(num)) {Console.WriteLine(num + " is a Prime Number");}
        // else {Console.WriteLine(num + " is not a Prime Number.");}
        // }
        // catch (Exception e){Console.WriteLine("Encountered the Error: "+ e.Message);}


        // // Check Armstrong Number
        // try {
        // if (isArmstrong(num)) {Console.WriteLine(num + " is an Armstrong Number.");}
        // else {Console.WriteLine(num + " is not an Armstrong Number.");}
        // } catch (Exception e){Console.WriteLine("Encountered the Error: "+ e.Message);}

        // // Check Palindrome
        // try {
        // if(IsPalindrome(num)) {Console.WriteLine(num +" is a Palindrome.");}
        // else {Console.WriteLine(num + " is not a Palindrome.");}
        // } catch (Exception e){Console.WriteLine("Encountered the Error: "+ e.Message);}

        // //Check GCD 
        // try
        // {
        //     Console.WriteLine("Enter the first number: ");
        //     string? input = Console.ReadLine();
        //     int.TryParse(input, out int num1);

        //     Console.WriteLine("Enter the second number: ");
        //     string? input1 = Console.ReadLine();
        //     int.TryParse(input, out int num2);

        //     GCD(num1,num2);
        // }
        // catch(Exception e) {Console.WriteLine("Encountered the error: "+e.Message);}

        // //Check LCM
        // try
        // {
        //     Console.WriteLine("Enter the first number: ");
        //     string? input = Console.ReadLine();
        //     int.TryParse(input, out int num1);

        //     Console.WriteLine("Enter the second number: ");
        //     string? input1 = Console.ReadLine();
        //     int.TryParse(input, out int num2);

        //     LCM(num1,num2);
        // }
        // catch(Exception e) {Console.WriteLine("Encountered the error: "+e.Message);}

        //Pascals Traingle
        // try{
        //     Console.WriteLine("Enter the number of rows: ");
        //     int rows = int.Parse(Console.ReadLine());
        //     PrintPascalsTriangle(rows);
        // } 
        // catch(Exception e) {Console.WriteLine("Error Encountered: "+e.Message);}

        //Binary to Decimal
        // try {
        // Console.WriteLine("Enter the binary number: ");
        // string? bin = Console.ReadLine();
        // Console.WriteLine(BinaryToDecimal(bin));
        // } catch(Exception e) {Console.WriteLine("Error Encountered: "+e.Message);}


        //Diamond Shape
        // try
        // {
        //     Console.WriteLine("Enter the number of rows/2 : ");
        //     int rows = int.Parse(Console.ReadLine());
        //     Diamond(rows);
        // } catch(Exception e) {Console.WriteLine("Error Encountered: "+e.Message);}

        //Calculate Factorial
        // try
        // {
        //     Console.WriteLine("Enter the number: ");
        //     int num = int.Parse(Console.ReadLine());
        //     Console.WriteLine(Factorial(num));
            
        // } catch(Exception e) {Console.WriteLine("Error Encountered: "+e.Message);}

        //Guess game
        // Guessgame();

        //Digital Root
        // try
        // {
        //     Console.WriteLine("Enter the number: ");
        //     int num = int.Parse(Console.ReadLine());
        //     Console.WriteLine(DigitalRoot(num));
            
        // } catch(Exception e) {Console.WriteLine("Error Encountered: "+e.Message);}


        //Skip Multiples of 3 
        // Skip3multiples();


        //Console Menu
        // ConsoleMenu();


        //Strong Number check
        // try
        // {
        //     Console.WriteLine("Enter the number: ");
        //     int num = int.Parse(Console.ReadLine());
        //     Console.WriteLine(IsStrongNumber(num));
            
        // } catch(Exception e) {Console.WriteLine("Error Encountered: "+e.Message);}

        //Deep Nested Search 
        try
        {
            Console.WriteLine("Enter the number: ");
            int num = int.Parse(Console.ReadLine());
            DeepNestedSearch(num);
            
        } catch(Exception e) {Console.WriteLine("Error Encountered: "+e.Message);}



        #endregion



    }
}
