//Multiple failures with WhenAll
//Create 3 tasks: two throw exceptions, one succeeds. Await WhenAll inside try/catch and print what happens.

public class MultipleFailures
{
    public static async Task Method1()
    {
        throw new Exception("Method 1 Exception");
    }
    public static async Task Method2()
    {
        throw new Exception("Method 2 Exception");
    }
    public static async Task Method3()
    {
        Console.WriteLine("Method 3 Called.");
    }
    public static async Task Main()
    {
        try
        {
            Task t1 = Method1();
            Task t2 = Method2();
            Task t3 = Method3();

            await Task.WhenAll(t1, t2, t3);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}