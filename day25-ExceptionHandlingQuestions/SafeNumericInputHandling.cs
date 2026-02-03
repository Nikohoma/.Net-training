using System;

class InputHandler
{
    static void Main()
    {
        // TODO:
        // 1. Read input from user
        // 2. Handle invalid numeric input
        // 3. Keep asking until valid number is entered

        while (true)
        {
            try
            {
                Console.WriteLine("Enter a Number: ");
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine("Number received successfully.");
                break;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error Encountered : "+e.Message);
            }
        }
    }
}