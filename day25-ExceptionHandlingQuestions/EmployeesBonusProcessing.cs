using System;

class BonusCalculator
{
    static void Main()
    {
        int[] salaries = { 5000, 0, 7000 };

        // TODO:
        // 1. Loop through salaries
        // 2. Divide bonus by salary
        // 3. Handle DivideByZeroException
        // 4. Continue processing remaining employees

        decimal bonus = 1500;
        foreach (var s in salaries)
        {
            try
            {
                decimal result = bonus / s;
                Console.WriteLine($"{result:F2}");
            }
            catch (DivideByZeroException) { Console.WriteLine("Cannot divide by zero."); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }


    }
}