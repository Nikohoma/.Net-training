//WhenAny winner
//Start two tasks. Use Task.WhenAny to print which one finished first.

public class WhenAny
{
    public static async Task<string> Method1()
    {
        await Task.Delay(2000);
        return "Method 1 Won";
    }

    public static async Task<string> Method2()
    {
        await Task.Delay(6000);
        return "Method 2 Won";
    }
    public static async Task Main()
    {
        Task<string> t1 = Method1();
        Task<string> t2 = Method2();
        var output = await Task.WhenAny(t1, t2);
        Console.WriteLine(await output);
        
    }
}