// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Net;
using System.Text.Json;

public class Class16
{
    public static async Task Main(string[] args)
    {
        FetchSynchronous();
        Console.WriteLine("=========================");
        await FetchASynchronous();   // await
    } 

    public static void FetchSynchronous()
    {
        string url = "https://jsonplaceholder.typicode.com/users/1";
        HttpClient client = new HttpClient();
        var response = client.GetAsync(url).Result;
        var result = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(result);
    }
    public static async Task FetchASynchronous()
    {
        string url = "https://jsonplaceholder.typicode.com/users/1";
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
    }
}