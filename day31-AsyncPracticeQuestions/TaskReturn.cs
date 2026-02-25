//Task<T> return
//Write Task<int> GetNumberAsync() that waits 300ms then returns 99. Print the result.

public class TaskMain
{
    public static async Task<int> GetNumberAsync()
    {
        await Task.Delay(3000);
        return 99;
    }
    public static async Task Main()
    {
        var result = await GetNumberAsync();
        Console.WriteLine(result);
    }
}