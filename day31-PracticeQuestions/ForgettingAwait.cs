//Forgetting await
//Create a method that starts a task but forgets to await it. Observe the output order. Then fix it by adding await.

public class ForgotAwait
{
    public static async Task MethodWithoutAwait()
    {
        await Task.Delay(5000);
        Console.WriteLine("Inside Async method");
    }

    public static async Task Main()
    {
        MethodWithoutAwait();
        Console.WriteLine("Method called without await.");
        await MethodWithoutAwait();
    }
}