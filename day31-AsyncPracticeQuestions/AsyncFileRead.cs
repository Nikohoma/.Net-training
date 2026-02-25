//Read a file asynchronously
//Create a text file with a few lines. Use File.ReadAllTextAsync to read it and print the contents.

public class ReadAsync
{
    public static async Task Main()
    {
        string filepath = @"C:\Users\nikhi\Downloads\May 12, 2025 (1).txt";
        var content  = await File.ReadAllTextAsync(filepath);
        Console.WriteLine(content);
        
    }
}