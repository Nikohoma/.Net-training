using System;

class ExceptionRethrow
{
    static void Main()
    {
        try
        {
            ProcessData();
        }
        catch (Exception e)
        {
            // TODO:
            // Handle final exception
            Console.WriteLine("\nError from ProcessData() :");
            Console.WriteLine(e.Message);
        }
    }

    static void ProcessData()
    {
        try
        {
            int.Parse("ABC");
        }
        catch (Exception e)
        {
            // TODO:
            // Log exception
            // Rethrow while preserving stack trace
            Console.WriteLine("Logged Error: ");
            Console.WriteLine(e.Message);
            throw;
        }
    }
}