//CancellationToken basics
//Create a loop that prints Working... every 300ms. Cancel after 1 second using CancellationTokenSource.CancelAfter.

public class Cancellation
{
    public static async Task Method(CancellationToken token)
    {
        while (true)
        {
            Console.WriteLine("Working");
            await Task.Delay(300,token);
        }
    }
    public static async Task Main()
    {
        using var cts = new CancellationTokenSource();
        cts.CancelAfter(1000);

        try
        {
            await Method(cts.Token);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}