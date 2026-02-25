//Exception handling
//Create a method that throws after a delay. Catch the exception at the await line and print the message.

public class ExceptionCatching
{
    public static async Task Method()
    {
        await Task.Delay(3000);
        throw new Exception("Custom Exception Caught.");
    }
    public static async Task Main()
    {
        try
        {
            await Method();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}