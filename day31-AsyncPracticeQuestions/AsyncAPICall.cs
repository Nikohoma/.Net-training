//Simulate a Web API call
//Write a method FetchUserAsync() that waits 700ms and returns a JSON-like string. Call it and print the result.
using System.Net.Http;
using System.Text.Json;
public class webAPI
{
    public static async Task Fetch()
    {
        HttpClient client = new HttpClient();
        string url = "https://jsonplaceholder.typicode.com/users/";
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode(); // throws if response not 2xx
        string content = await response.Content.ReadAsStringAsync();  // ReadAsString() for json
        Console.WriteLine(content);
    }
    public static async Task Main()
    {
        await Fetch();
    }
}