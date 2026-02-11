using System;
using System.IO;

namespace FileHandling
{
    public class ReadFile
    {
        public void ReadContent()
        {
            string filePath = @"C:\Users\nikhi\Downloads\github-recovery-codes.txt";

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void ReadContentWithoutStreamWriter()
        {
            string filePath = @"C:\Users\nikhi\Downloads\github-recovery-codes.txt";
            var content = File.ReadAllText(filePath);
            Console.WriteLine(content);
        }
    }

    public class WriteFile
    {
        public void WriteContent()
        {
            string filePath = @"C:\Users\nikhi\Downloads\May 12, 2025 (1).txt";

            using(var writer = new StreamWriter(filePath, append:true))
            {
                writer.WriteLine("\nWritten using StreamWriter.");
                
            }
        }

        public void OverwriteContentWithFile()
        {
            string filePath = @"C:\Users\nikhi\Downloads\May 12, 2025 (1).txt";
            File.WriteAllText(filePath, "This is written with File.");
            File.AppendAllText(filePath, "\nThis is appended with File.");
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            ReadFile read = new ReadFile();
            read.ReadContent();
            WriteFile write = new WriteFile();
            write.WriteContent();
            Console.WriteLine("\nReading without StreamWriter :");
            read.ReadContentWithoutStreamWriter();
            write.OverwriteContentWithFile();
        }
    }

}