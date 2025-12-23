using System;

class newClass
{

    // check Prime Number
    static bool ifPrime(int n)
    {
        if (n<=1) {return false;}
        if (n==2) {return true;}

        for (int i = 3; i*i <= n ; i+=2)
        {
            if (n%i == 0)
            {
                return false;
            }
        }
        return true;
    }
    static void Main()
    {   
        // Console.WriteLine("Enter Your Name: ");
        // string? name = Console.ReadLine();

        // Console.WriteLine("Hello, "+name+"!");



        // Prime Number Check
        // Console.WriteLine("Enter The number: ");
        // int n = int.Parse(Console.ReadLine());
        // ifPrime(n);

        // if (ifPrime(n)) {Console.WriteLine("Prime");}
        // else {Console.WriteLine("Not Prime");}




        // Check Age
        // Console.WriteLine("Enter the Age: ");
        // string? input = Console.ReadLine();

        // if (int.TryParse(input, out int age)) {     //TryParse(input, out int n)
        //     bool isAdult = age >= 18;      //isAdult = true/false
        //     Console.WriteLine("Adult? "+isAdult);
        //     }
        // else {Console.WriteLine("Invalid Age");}



        // Feet into Centimeters
        Console.WriteLine("Enter the measurement in feet:");
        string? input = Console.ReadLine();

        if (!double.TryParse(input, out double val)) { Console.WriteLine("Invalid Value detected; enter a valid value."); }
        else {
            double cms = val * 30.48;
            Console.WriteLine("CMs: "+ cms);
            }



    }


    }
