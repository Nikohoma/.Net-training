namespace MainClass;

using Classes;


public class MainClass
{
    public static void Main(string[] args)
    {
        Linq l = new Linq();
        l.LinqEx();
        Console.WriteLine(l.IsPalindrome("AJA"));



        string[] names = { "AJA", "BAB", "CKL" };

        Console.WriteLine("\nLinq Palindrome: ");
        var newLinqObjects = from n in names
                             select l.IsPalindrome(n);

        foreach (var x in newLinqObjects)
        {
            Console.WriteLine(x);
        }


        Console.WriteLine("\nProcess with Linq");
        Linq.LinqEx1();

        Linq.LinqEx3();

        #region Linq on Generics  (reger Notes of Generics + LINQ)
        List<ClassRoom> StudentList = new List<ClassRoom>
        {
            new ClassRoom(1,23,43),
            new ClassRoom(2,34,23),
            new ClassRoom(3,21,34),
            new ClassRoom(4,23,12)
        };

        Console.WriteLine("\nMaximum Average: ");
        var maxAverage = StudentList.Max(s => (s.Mark1 + s.Mark2) / 2);
        Console.WriteLine(maxAverage);

        var top = StudentList.Select(s => new { Average = (s.Mark1 + s.Mark2) / 2 }).OrderByDescending(x => x.Average).FirstOrDefault();      
        Console.WriteLine(top);

        // List Containing ID and corresponding average of marks
        var averages = StudentList.Select(s => new {Average = (s.Mark1 + s.Mark2) / 2 });  // s = Anonymous object
        Console.WriteLine(averages);
        foreach (var a in averages) { Console.Write(a); }
        #endregion

        #region Linq on Collections // Not suitable for linq since collections take input in the form of objects.
        Stack<ClassRoom> myStack = new Stack<ClassRoom>();
        myStack.Push(new ClassRoom(11,23,43));
        myStack.Push(new ClassRoom(12, 33, 42));
        myStack.Push(new ClassRoom(13, 83, 53));

        var AverageStack = myStack.Select(a => new { Average = (a.Mark1 + a.Mark2) / 2 } ).OrderByDescending(x=>x.Average).Skip(1).First();
        Console.WriteLine("\nSecond maximum Average of Stack : ");
        Console.WriteLine(AverageStack);
        
        #endregion

    }
}