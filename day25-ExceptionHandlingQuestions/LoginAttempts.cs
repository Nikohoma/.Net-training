using System;


/// <summary>
/// Custom Exception
/// </summary>
public class LoginAttemptExceeded : Exception
{
    public LoginAttemptExceeded() : base("Maximum Login Attempt Reached.")
    {
    }
}

class LoginSystem
{
    static void Main()
    {
        int attempts = 4;

        // TODO:
        // 1. Allow only 3 login attempts
        // 2. Create and throw custom exception after limit
        // 3. Handle exception and terminate application

        try
        {
            if (attempts > 3)
            {
                Console.WriteLine("Application Terminated.");
                throw new LoginAttemptExceeded();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error Encountered : "+e.Message);
        }

    }
}