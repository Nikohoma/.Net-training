using System;

namespace ThreadingExamples;

/// <summary>
/// 1 file = 1 thread
/// </summary>
public class Threading
{
    public static void Run1()
    {
        Console.WriteLine("Even for Loop: ");
        for (int i =0; i < 100; i += 2)
        {
            Thread.Sleep(100); //ms
            Console.Write(i + " ");
        }

        Console.WriteLine("\nOdd for Loop: ");
        for (int i = 1; i < 100; i += 2)
        {
            Thread.Sleep(100);
            Console.Write(i + " ");
        }

    }

    /// <summary>
    /// Multi threading
    /// </summary>
    public static void Task1()
    {
        Console.WriteLine("Even for Loop in MultiThreading: ");
        for (int i = 0; i < 100; i += 2)
        {
            Thread.Sleep(100); //ms
            Console.Write(i + " ");
        }
    }

    public static void Task2()
    {
        Console.WriteLine("Odd for Loop in MultiThreading: ");
        for (int i = 1; i < 100; i += 2)
        {
            Thread.Sleep(100); //ms
            Console.Write(i + "*");
        }
    }

    /// <summary>
    /// Multi Tasking / Parallel Processing : Aysnc and Await 
    /// </summary>
    /// <returns></returns>
    
    public static async Task Asyncmethod()   // Task here = void. If need to return some value use Task<returnType>. With Task, program will work parallely
    {
        Console.WriteLine("Task Started");
        await Task.Delay(3000);      // Waiting for 3 seconds
        Console.WriteLine("Task completed after 3 seconds");
    }


    /// <summary>
    /// To call async methods.
    /// </summary>
    public async Task CallMethod()
    {
        await Asyncmethod();
        string data = await Threading.FetchData("https://jsonplaceholder.typicode.com/todos/");
        Console.WriteLine("Fetching Data");
        Console.WriteLine(data);
        
    }

    /// <summary>
    /// Async and await example
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static async Task<string> FetchData(string url)
    {
        using (HttpClient client = new HttpClient()) 
        { 
            var response = await client.GetStringAsync(url);
            return response; 
        }
    }

    public class FileHandling
    {
        public void WriteFile()
        {
            string[] lines = { "First Line", "Second Line", "Third Line" };

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath,"WriteLines.txt")))
            {
                foreach (string line in lines) { outputFile.WriteLine(line); }
            }

        }

        public void ReadFile()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string FilePath = Path.Combine(docPath, "WriteLines.txt");

            using (StreamReader reader = new StreamReader(FilePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }

}


