using System;

class Program
{

    // Height Category Check
    static void CategorizeHeight()
    {
        try
        {
            Console.Write("Enter your height in cm: ");
            int height = int.Parse(Console.ReadLine());

            if (height < 0) {Console.WriteLine("Enter Valid Height.");}
            else if (height < 150) {Console.WriteLine("Dwarf");}
            else if (height <= 165) {Console.WriteLine("Average");}
            else if (height <= 190) {Console.WriteLine("Tall");}
            else {Console.WriteLine("Abnormal");}
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }


    // Maximum among three
    static void Maximumthree(int a, int b, int c)
    {
        try
        {
            if (a > b && a > c) {Console.WriteLine(a+" is the greatest.");}
            else if (b>a && b>c) {Console.WriteLine(b +" is the greatest.");}
            else {Console.WriteLine(c +" is the greatest.");}
        } catch {Console.WriteLine("An Error Occured");}
    }


    //Method to check If a Year is a leap year
    static void CheckLeapYear(int n)
    {
        if ((n % 400 == 0) || (n % 4 == 0 && n % 4 != 0 )) {Console.WriteLine(n +" is a Leap Year.");}
        else {Console.WriteLine(n +" is not a Leap Year.");}
    }


    // Method to calculate roots
    static void CalculateRoots(double a, double b, double c)
    {
        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine("Roots : "+root1+" and " +root2);
        }
        else if (discriminant == 0)
        {
            double root = -b / (2 * a);
            Console.WriteLine("One root only: "+root);
        }
        else
        {
            double real = -b / (2 * a);
            double imaginary = Math.Sqrt(-discriminant) / (2 * a);
            Console.WriteLine("Complex Roots: "+real +" +"+imaginary+"i and"+real+" -"+imaginary+"i" );
        }
    }


    // Check Eligibilty
    static void CheckEligibility(int math, int physics, int chemistry)
    {
        int total = math + physics + chemistry;

        if (math >= 65 && physics >= 55 && chemistry >= 50 &&
            (total >= 180 || (math + physics) >= 140))
        {
            Console.WriteLine("Eligible");
        }
        else
        {
            Console.WriteLine("Not Eligible");
        }
    }


    // Bill Calculate
    static double CalculateBill(int units)
    {
        double bill = 0;

        if (units <= 199)
            bill = units * 1.20;
        else if (units <= 400)
            bill = 199 * 1.20 + (units - 199)*1.50;
        else if (units <= 600)
            bill = 199 * 1.20 + 201 * 1.50 + (units - 400)*1.80;
        else
            bill = 199 * 1.20 + 201 * 1.50 + 200 * 1.80 + (units - 600)*2.00;

        if (bill > 400) {bill += bill * 0.15;}

        return bill;
    }


    //Check Vowel
    static bool IsVowel(char ch)
    {
        switch (char.ToLower(ch))
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                return true;
            default:
                return false;
        }
    }


    // Check type of triangle
    static void CheckTriangleType(double a, double b, double c)
    {
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            Console.WriteLine("Invalid triangle.");
            return;
        }

        if (a == b && b == c) Console.WriteLine("Equilateral triangle");
        else if (a == b || b == c || a == c) Console.WriteLine("Isosceles triangle");
        else Console.WriteLine("Scalene triangle");
    }


    // Check Quadrant
    static void CheckQuadrant(int x, int y)
    {
        if (x == 0 && y == 0) Console.WriteLine("The point is at the Origin.");
        else if (x == 0) Console.WriteLine("The point lies on the Y-axis.");
        else if (y == 0) Console.WriteLine("The point lies on the X-axis.");
        else if (x > 0 && y > 0) Console.WriteLine("The point lies in Quadrant I.");
        else if (x < 0 && y > 0) Console.WriteLine("The point lies in Quadrant II.");
        else if (x < 0 && y < 0) Console.WriteLine("The point lies in Quadrant III.");
        else Console.WriteLine("The point lies in Quadrant IV.");
    }


    //Check Result
    static void Result(char grade)
    {
        switch (char.ToUpper(grade))
        {
            case 'E':
                Console.WriteLine("Excellent");
                break;
            case 'V':
                Console.WriteLine("Very Good");
                break;
            case 'G':
                Console.WriteLine("Good");
                break;
            case 'A':
                Console.WriteLine("Average");
                break;
            case 'F':
                Console.WriteLine("Fail");
                break;
            default:
                Console.WriteLine("Invalid grade entered.");
                break;
        }
    }


    // Valid Date
    static void CheckValidDate(int day, int month, int year)
    {
        if (DateTime.TryParse($"{year}-{month}-{day}", out DateTime date))
            Console.WriteLine(day +"-"+ month+"-"+year+" is a valid date.");
        else
            Console.WriteLine(day +"-"+ month+"-"+year+" is an invalid date.");
    }

    // Bank Account
    static void BankAccount(bool cardInserted, int enteredPin, int correctPin, double balance, double withdrawalAmount)
    {
        if (cardInserted)
        {
            Console.WriteLine("Card detected.");

            if (enteredPin == correctPin)
            {
                Console.WriteLine("PIN is correct.");

                if (balance >= withdrawalAmount)
                {
                    Console.WriteLine("Collect "+withdrawalAmount);
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }
            else
            {
                Console.WriteLine("Invalid PIN.");
            }
        }
        else
        {
            Console.WriteLine("Insert your card.");
        }
    }


    // Calculate Profit or Loss
    static void CalculateProfitOrLoss(double costPrice, double sellingPrice)
    {
        double difference = sellingPrice - costPrice;

        if (difference > 0)
        {
            double profitPercent = (difference / costPrice) * 100;
            Console.WriteLine($"Profit: {difference:C}, Profit Percentage: {profitPercent:F2}%");
        }
        else if (difference < 0)
        {
            double lossPercent = (-difference / costPrice) * 100;
            Console.WriteLine($"Loss: {-difference:C}, Loss Percentage: {lossPercent:F2}%");
        }
        else
        {
            Console.WriteLine("No profit, no loss.");
        }
    }

    // Rock,Paper and Scissors
    static void RockPaperScissors(string player1Choice, string player2Choice)
    {
        string p1 = player1Choice.ToLower();
        string p2 = player2Choice.ToLower();

        if (p1 == p2)
        {
            Console.WriteLine("It's a tie!");
            return;
        }

        if (p1 == "rock")
        {
            if (p2 == "scissors")
                Console.WriteLine("Player 1 wins! Rock beats Scissors.");
            else
                Console.WriteLine("Player 2 wins! Paper beats Rock.");
        }
        else if (p1 == "paper")
        {
            if (p2 == "rock")
                Console.WriteLine("Player 1 wins! Paper beats Rock.");
            else
                Console.WriteLine("Player 2 wins! Scissors beats Paper.");
        }
        else if (p1 == "scissors")
        {
            if (p2 == "paper") Console.WriteLine("Player 1 wins! Scissors beats Paper.");
            else Console.WriteLine("Player 2 wins! Rock beats Scissors.");
        }
        else
        {
            Console.WriteLine("Invalid input from Player 1.");
        }
    }

    // Calculator
    static void Calculator(double a, double b, char o)
    {
        switch (o)
        {
            case '+':
                Console.WriteLine($"Result = {a + b}");
                break;

            case '-':
                Console.WriteLine($"Result = {a - b}");
                break;

            case '*':
                Console.WriteLine($"Result = {a * b}");
                break;

            case '/':
                if (b != 0)
                    Console.WriteLine($"Result = {a / b}");
                else
                    Console.WriteLine("Error: Division by zero!");
                break;

            default:
                Console.WriteLine("Invalid operator! Use one of +  -  *  /");
                break;
        }
    }





    // Main class
    static void Main()
    {
        // Height Category 
        // CategorizeHeight();

        //Maximum number among three
        // try
        // {
        //     Console.WriteLine("Enter the first Number: ");
        //     int num1 = int.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter the second Number: ");
        //     int num2 = int.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter the third Number: ");
        //     int num3 = int.Parse(Console.ReadLine());

        //     Maximumthree(num1,num2,num3);
        // } catch (Exception e) {Console.WriteLine("Error Occured: "+e.Message);}


        //Check Leap Year
        // try
        // {
        //     Console.WriteLine("Enter the Year to check if its a Leap Year: ");
        //     int year = int.Parse(Console.ReadLine());
        //     CheckLeapYear(year);

        // } catch(Exception e) {Console.WriteLine("An Error Occured: "+e.Message);}



        //Calculate Roots
        // try
        // {
        //     Console.WriteLine("Enter a: ");
        //     int num1 = int.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter b: ");
        //     int num2 = int.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter c: ");
        //     int num3 = int.Parse(Console.ReadLine());

        //     CalculateRoots(num1,num2,num3);
        // } catch (Exception e) {Console.WriteLine("Error Occured: "+e.Message);}


        // Check Eligibility
        // try
        // {
        //     Console.WriteLine("Enter Maths Marks: ");
        //     int maths = int.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter Physics Marks: ");
        //     int physics = int.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter Chemistry Marks: ");
        //     int chemistry = int.Parse(Console.ReadLine());

        //     CheckEligibility(maths,physics,chemistry);
        // } catch (Exception e) {Console.WriteLine("Error Occured: "+e.Message);}


        //Calculate Bill 
        // try
        // {
        //     Console.WriteLine("Enter your units: ");
        //     int units = int.Parse(Console.ReadLine());
        //     Console.WriteLine(CalculateBill(units));
        // } catch (Exception e) {Console.WriteLine("An Error Occured: "+e.Message);}


        //Check Vowel
        // try
        // {
        //     Console.WriteLine("Enter a character: ");
        //     char Char = char.Parse(Console.ReadLine());
        //     Console.WriteLine(IsVowel(Char));
            
        // }catch (Exception e){ Console.WriteLine("An Error Occured : "+e.Message);}



        //Check triangle Type
        // try
        // {
        //     Console.WriteLine("Enter first side: ");
        //     double side1 = double.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter second side: ");
        //     double side2 = double.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter third side: ");
        //     double side3 = double.Parse(Console.ReadLine());

        //     CheckTriangleType(side1,side2,side3);
        // } catch (Exception e) {Console.WriteLine("Error Occured: "+e.Message);}


        // Check Quadrant
        // try {
        //     Console.WriteLine("Enter the x-axis point" );
        //     int pnt1 = int.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter the y-axis point" );
        //     int pnt2 = int.Parse(Console.ReadLine());

        //     CheckQuadrant(pnt1,pnt2);
        // } catch(Exception e) {Console.WriteLine("An Error occured: "+e.Message);}


        // Check Result based on grade
        // try {
        //     Console.WriteLine("ENter your grade: ");
        //     char grade = char.Parse(Console.ReadLine());
        //     Result(grade);
        // } catch(Exception e) {Console.WriteLine("Error: "+e.Message);}


        //Check Valid Date
        // try
        // {
        //     Console.WriteLine("Enter the day: ");
        //     int day = int.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter the month: ");
        //     int month = int.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter the year: ");
        //     int year = int.Parse(Console.ReadLine());

        //     CheckValidDate(day,month,year);
        // } catch (Exception e) {Console.WriteLine("Error Occured: "+e.Message);}


        // Bank Account
        // try {
        //     Console.WriteLine("Type true if Card Inserted else type false");
        //     bool cardInserted = bool.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter your PIN : ");
        //     int pin = int.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter PIN again: ");
        //     int correctPin = int.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter your Account balance: ");
        //     double balance = double.Parse(Console.ReadLine());
        //     Console.WriteLine("Enter the Withdrawal Amount: ");
        //     double amount = double.Parse(Console.ReadLine());
        //     BankAccount(cardInserted,pin,correctPin,balance,amount);
        // } catch(Exception e) {Console.WriteLine("Error Encountered: "+e.Message);}


        // Calculate Profit or Loss

        // try {
        //     Console.WriteLine("ENter the cost Price: ");
        //     double cp = double.Parse(Console.ReadLine());
        //     Console.WriteLine("ENter the selling Price: ");
        //     double sp = double.Parse(Console.ReadLine());

        //     CalculateProfitOrLoss(cp,sp);
        // } catch(Exception e) {Console.WriteLine("Error: "+e.Message);}


        // Rock, Paper and Scissors
        // try
        // {
        //     Console.WriteLine("First Player, Enter your choice: ");
        //     string choice1 = Console.ReadLine();
        //     Console.WriteLine("Second Player, Enter your choice: ");
        //     string choice2 = Console.ReadLine();

        //     RockPaperScissors(choice1,choice2);
        // }catch (Exception e) {Console.WriteLine("Error: "+e.Message);}


        // Calculator
        Console.WriteLine("Enter the first number: ");
        double num1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second number: ");
        double num2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the operation: ");
        char oper = char.Parse(Console.ReadLine());

        Calculator(num1,num2,oper);





    }
}