//Chain async methods
//Make AAsync() await BAsync(), and BAsync() await a delay. Print messages so you can see the chain.

public class ChainAsync
{
    public static async Task AAsync()
    {
        await BAsync();
        Console.WriteLine("Print from A Async.");

    }

    public static async Task BAsync()
    {
        await Task.Delay(5000);
        Console.WriteLine("Print from B Async.");
    }
    public static async Task Main()
    {
        await AAsync();
    }
}