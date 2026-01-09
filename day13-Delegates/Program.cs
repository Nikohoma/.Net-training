namespace MainClass;

using day13;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

public class MainClass
{
    public static void Main(string[] args)
    {
        PrintingCompany printingCompany = new PrintingCompany();
        printingCompany.CustomerChoicePrintMessage = new PrintMessage(HappyNewYear);
        printingCompany.PrintMessage("Ram");


        #region Multi-cast Delegates Instances invoking Methods
        Console.WriteLine("\nMulti Cast Delegates.");

        // Accessing Static Functions
        multiCastDelegate.myDelegate d = multiCastDelegate.MethodA;
        d += multiCastDelegate.MethodB;
        d += multiCastDelegate.MethodC;

        // Invoke
        d("Hello ");
        #endregion


        #region Do-Select Test - Person details
        Console.WriteLine("\nDo Select Test Person Details Outputs: ");
        IList<Person> p = new List<Person>();  // Created a list of Person Data type
        // Adding Person objects into the List.
        p.Add(new Person { Name = "A", Address = "Delhi", Age = 23 });
        p.Add(new Person { Name = "B", Address = "Mumbai", Age = 24 });
        p.Add(new Person { Name = "C", Address = "Noida", Age = 21 });

        PersonImplementation pi = new PersonImplementation();
        pi.GetName(p);
        Console.WriteLine(pi.Average(p));
        Console.WriteLine(pi.Max(p));
        Console.WriteLine("Second Highest Age: "+ pi.SecondHighest(p));


        #endregion

        #region Do-Select Test - Method Overloading
        Console.WriteLine("\nDo select Test Method Overloading Outputs: ");
        Source source = new Source();
        Console.WriteLine(source.Add(1, 2, 3));
        Console.WriteLine(source.Add(1.2, 3.2, 43.2)); 


        #endregion

        #region 
        Console.WriteLine("\nEmployee Class Output: ");
        Employee e1 = new Employee(1,"A",44000);
        Employee e2 = new Employee(5, "A", 44000);
        Employee e3 = new Employee(2, "A", 44000);
        Employee e4 = new Employee(8, "A", 44000);

        e1.DisplayDetails();

        #endregion


    }

    private static string HappyNewYear(string message)
    {
        return "Happy New Year";
    }
}