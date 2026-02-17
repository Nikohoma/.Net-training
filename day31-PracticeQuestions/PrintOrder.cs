//1) Print order
//Create an async method that prints Start, awaits Task.Delay(500), then prints End. Call it from Main.


public class AsyncMainClass
{
    public static async Task Print()
    {
        Console.WriteLine("Start");
        await Task.Delay(500);
        Console.WriteLine("End");
    }
    public async static Task Main(string[] args)
    {
        await Print();
    }
}