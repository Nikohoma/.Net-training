using System;

class DatabaseConnection
{
    static void Main()
    {
        // TODO:
        // 1. Open connection
        // 2. Simulate operation failure
        // 3. Ensure connection is closed properly
        bool connected = false;

        try
        {
            // 1
            connected = true;
            // 2
            throw new Exception("Database Connection Failed");

        }
        catch (Exception e)
        {
            Console.WriteLine("Error Encountered : "+ e.Message);
        }
        finally
        {
            // 3
            if (connected)
            {
                connected = false;
                Console.WriteLine("Database connection closed.");
            }
        }
    }
}