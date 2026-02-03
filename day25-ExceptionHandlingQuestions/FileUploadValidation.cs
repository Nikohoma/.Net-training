using System;
using System.Text.RegularExpressions;

class FileUpload
{
    static void Main()
    {
        string fileName = "report.ee";
        int fileSize = 81; // MB

        // TODO:
        // 1. Validate file extension
        // 2. Validate file size
        // 3. Throw and handle appropriate exceptions

        try
        {
            bool validExe = Regex.IsMatch(fileName, @".exe$");
            if (!validExe)
            {
                throw new Exception("File should be an .exe type.");
            }
            if (fileSize > 10)
            {
                throw new Exception("File cannot be larger than 10 MB.");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Error Encountered : "+e.Message);
        }
    }
}