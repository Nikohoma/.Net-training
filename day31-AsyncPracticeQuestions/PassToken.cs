//Pass the token
//Create OuterAsync(token) that calls InnerAsync(token) and passes the token through.

public class TokenPass
{
    public static async Task InnerAsync(CancellationToken token)
    {
        await Task.Delay(3000,token);
        Console.WriteLine("Inner Async Method Executed.");
    }
    public static async Task OuterAsync(CancellationToken token)
    {
        await InnerAsync(token);
        await Task.Delay(2000, token);
        Console.WriteLine("Outer Async Executed.");

    }
    public static async Task Main()
    {
        using var cts = new CancellationTokenSource();
        cts.CancelAfter(4000);

        try
        {
            await OuterAsync(cts.Token);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}