using System.Xml.Serialization;
using DataSerialization;
using System.Text.Json;
using System.Diagnostics;


///Main Class

public class MainClass
{
    public static void Main(string[] args)
    {
        #region Instances

        /// Object Initialization
        Student s = new Student();
        s.Id = 1; s.Name = "Nikhil"; s.Scores = new int[] { 10, 32, 13 }; s.Subjects = new List<string> { "Maths", "Science", "Zoology" };

        Student s1 = new Student();
        s1.Id = 2; s1.Name = ""; s1.Scores = [12, 34, 23, 12]; s1.Subjects = ["History", "Geography", "Civics"];

        XmlSerializer serializer = new XmlSerializer(typeof(Student));  // Converts object into serialised XML format.
        #endregion

        /// String Writer write text to string, Console.WriteLine writes text to screen, FileWriter writes text to file.
        /// XML Serializer needs a text writer to write the XML content.
        /// String Writer writes data into RAM (string buffer). Therefore faster than File Handling.
        var sw = new StringWriter();
        serializer.Serialize(sw, s);   // Convert object s into xml and writes into sw. 

        string xml = sw.ToString();    // Converting xml to string.
        Console.WriteLine(xml);

        serializer.Serialize(Console.Out, s1); // Convert object s1 into xml and writes into Console.

        /// JSON Serialization
        Console.WriteLine("\nJSON SERIALIZATION");

        string jsonString = JsonSerializer.Serialize(s);
        Console.WriteLine(jsonString);

        string jsonString1 = JsonSerializer.Serialize(s1);
        Console.WriteLine(jsonString1);

        /// Writing data to a File
        string Filename = "StudentData.json";
        File.WriteAllText(Filename, jsonString1);

        /// Reading from a file
        Console.WriteLine("\nReading File :");
        Console.WriteLine(File.ReadAllText(Filename));


        /// All Processes into JSON Format
        List<String> processList = new List<string>();  // List to store all the process' Names

        // To Loop through all the processes and retrieve their name.
        foreach(var p in Process.GetProcesses())
        {
            processList.Add(p.ProcessName);
        }

        // Serializing into JSON and storing it.
        string JsonProcess = JsonSerializer.Serialize(processList);
        Console.WriteLine("\nProcesses in JSON Format: ");
        Console.WriteLine(JsonProcess);

        // Deserialize 

        //string ProcessDeserialized = JsonSerializer.Deserialize<string>(Filename);
        //Console.WriteLine("\nProcesses Deserialized: ");
        //Console.WriteLine(ProcessDeserialized);


        /// Delegate 
        Console.WriteLine("\nDelegates: ");
        ExampleOfDelegate exampleOfDelegate = new ExampleOfDelegate();
        exampleOfDelegate.DelegateEx1();

        Console.WriteLine("\nSubtraction Delegate: ");
        SubtractionClass obj = new SubtractionClass();
        obj.SubtractionMethod(5, 4);
    }
}