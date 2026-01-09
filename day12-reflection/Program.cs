using System.ComponentModel;
using System.Reflection;

namespace Reflection;

public class ReflectionExample
{
    public static void Main(string[] args)
    {
        // Loads an assembly using its file name.
        Assembly a = Assembly.LoadFrom("C:\\Users\\nikhi\\OneDrive\\Pictures\\Documents\\csharp\\dllsource\\Assessment2.dll");  // Assembly here refers to a .dll or .exe file . Just an object that contains compiled code in the form of Intermediate Language (IL).

        // Gets all the data types (class) defined in the assembly object.
        Type[] dataType = a.GetTypes(); 
        // Displays the full names of all the classes defined in the assembly.
        foreach (Type t in dataType)
        {
            Console.WriteLine(t.FullName);
        }

        // Getting Properties of a class using Reflection
        Console.WriteLine($"\nProperties of {dataType[1].FullName}: ");
        var properties = dataType[1].GetProperties(); // Gets all the properties defined in the second class(type[1]) of the assembly.
        foreach (var p in properties)
        {
            Console.WriteLine($"Property Name: {p.Name} , Type : {p.PropertyType}");
        }

        //Get Fields of a class using Reflection
        Console.WriteLine("\nGet Fields: ");
        var fields = dataType[1].GetFields(); // Gets all the fields defined in the second class(type[1]) of the assembly. GetFields (BindingFlags.NonPublic | BindingFlags.Instance) => to get private fields specifically.
        foreach (var f in fields)
        {
            Console.WriteLine($"Fields Name : {f.Name}");
        }

    }
}