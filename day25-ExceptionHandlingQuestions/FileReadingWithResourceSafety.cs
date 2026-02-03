using System;
using System.IO;

class FileReader
{
    static void Main()
    {
        //string filePath = "C:\\Users\\nikhi\\OneDrive\\Pictures\\Documents\\csharp\\Sceanrio Based Practice Questions On Csharp.docx";
        string filePath = "C:\\Users\\nikhi\\OneDrive\\Pictures\\Documents\\csharp\\Sceanrio Based Practice Questions On .docx";

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine("Content : ");
                Console.WriteLine(content);
            }
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("File Path Not valid. Please Check Again.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You are not authorized to access the file.");
        }
        catch (Exception e) { Console.WriteLine($"Error Encountered : {e.Message}"); }
        

        // TODO:
        // 1. Read file content
        // 2. Handle FileNotFoundException
        // 3. Handle UnauthorizedAccessException
        // 4. Ensure resource is closed properly
    }
}