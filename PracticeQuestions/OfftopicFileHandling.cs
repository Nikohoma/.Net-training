using System.IO;

namespace FileHandlingPractice
{
    public class ReadAndWriteWithFile
    {
        public void ReadFile()
        {
            string filePath = @"C:\Users\nikhi\Downloads\May 12, 2025 (1).txt";
            var content = File.ReadAllText(filePath);
            Console.WriteLine(content);
        }
        public void WriteFile()
        {
            string filePath = @"C:\Users\nikhi\Downloads\May 12, 2025 (1).txt";
            var input = "Writing this into the file";
            File.WriteAllText(filePath, input);
        }

        public void AppendFile()
        {
            string filePath = @"C:\Users\nikhi\Downloads\May 12, 2025 (1).txt";
            string input = "\nAppending into the File.";
            File.AppendAllText(filePath, input);
        }
    }

    public class ReadAndWriteWithStream
    {
        public void StreamReadFile()
        {
            string filePath = @"C:\Users\nikhi\Downloads\May 12, 2025 (1).txt";
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while( (line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void StreamWriteFile()
        {
            string filePath = @"C:\Users\nikhi\Downloads\May 12, 2025 (1).txt";
            using (var writer = new StreamWriter(filePath, true))  // append = true
            {
                writer.WriteLine("\nLine 3 with Stream Writer");
            }
        }
    }

    public class MainClass
    {
        public static void Main()
        {
            ReadAndWriteWithFile io = new ReadAndWriteWithFile();
            io.WriteFile();
            io.AppendFile();
            io.ReadFile();

            Console.WriteLine("\nStream IO :");
            ReadAndWriteWithStream io1 = new ReadAndWriteWithStream();
            io1.StreamWriteFile();
            io1.StreamReadFile();
        }
    }
}