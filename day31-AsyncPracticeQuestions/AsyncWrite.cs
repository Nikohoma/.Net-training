//Write a file asynchronously
//Ask the user for a line of text and write it using File.WriteAllTextAsync.

public class WriteAsync
{
    public static async Task Main(string[] args)
    {
        string filePath = @"C:\Users\nikhi\Downloads\May 12, 2025 (1).txt";
        await File.AppendAllTextAsync(filePath, "\nThis is written asynchronously.");

        Console.WriteLine("Appended Asynchronously.");

        var content = await File.ReadAllTextAsync(filePath);
        Console.WriteLine(content);

    }
}