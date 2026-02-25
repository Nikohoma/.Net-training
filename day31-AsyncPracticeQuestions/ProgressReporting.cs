//Progress reporting
//Create a method that does 10 steps and prints progress (1/10 ... 10/10) with delays. (Hint: keep it simple: just print.)

public class Progress
{
    public static async Task Method()
    {
        Console.WriteLine("1/5");
        await Task.Delay(1000);
        Console.WriteLine("2 / 5");
        await Task.Delay(2000);
        Console.WriteLine("3 / 5");
        await Task.Delay(3000);
        Console.WriteLine("4 / 5");
        await Task.Delay(4000);
        Console.WriteLine("5 / 5");

    }
    public static async Task Main(string[] args)
    {
        await Method();
    }
}