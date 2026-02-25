//Convert sync to async
//Start with a sync method that waits using Thread.Sleep.Convert it to async using Task.Delay and return Task.

public class SyncAsync
{
    public static void Sync()
    {
        Thread.Sleep(3000);
        Console.WriteLine("Sync Method");
    }

    public static async Task Async()
    {
        await Task.Delay(3000);
        Console.WriteLine("Async Method");
    }
    public static async Task Main()
    {
        Sync();
        await Async();
    }
}