//WhenAll with 3 tasks
//Start three tasks with different delays (200ms, 400ms, 700ms). Await them using Task.WhenAll.Print all results.

public class WhenAllAsync
{
    public static async Task<string> Method1()
    {
        await Task.Delay(2000);
        return "Method1 Executed.";
    }
    public static async Task<string> Method2()
    {
        await Task.Delay(4000);
        return "Method2 Executed";
    }
    public static async Task<string> Method3()
    {
        await Task.Delay(5000);
        return "Method3 Executed";
    }
    public static async Task Main()
    {
        Task<string>t1 = Method1();
        Task<string> t2= Method2();
        Task<string> t3 = Method3();
        var result = await Task.WhenAll(t1, t2, t3);  // takes 5000 ms (maximum)
        foreach (var r in result)
        {
            Console.WriteLine(r);
        }
    }
}