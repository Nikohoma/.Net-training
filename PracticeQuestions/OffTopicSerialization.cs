using System;
using System.IO;
using System.Xml.Serialization;

public class Class13
{
    public int Id { get; set; }
    public string Name { get; set; }
}


public class MainClass44
{
    public static void Main()
    {
        Class13 c = new Class13()
        {
            Id = 1,
            Name = "Nikhil"
        };

        XmlSerializer xml = new XmlSerializer(typeof(Class13));

        xml.Serialize(Console.Out, c); // To Screen

        // XML To File
        using (var file = new FileStream("XML OUTPUT", FileMode.Create))
        {
            xml.Serialize(file, c);
        }

        // StringWriter
        using (var writer = new StringWriter())
        {
            xml.Serialize(writer, c);
            Console.WriteLine(writer.ToString());
        }

        
    }

}