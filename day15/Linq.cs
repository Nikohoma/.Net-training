namespace Classes;

public class Linq
{
	// Constructor
	public Linq()
	{

	}

	public void LinqEx()
	{
		string[] names = { "A", "B", "C" };

		// Normal way
		foreach(var i in names)
		{
			if (i == "B") { Console.WriteLine($"B is present"); }
		}

		// Linq 
		Console.Write("Linq Equivalent: ");
		var findName = from i in names
					   where i == "B"
					   select i;
		if (findName != null) { Console.WriteLine("B is present"); }

		// Order by
        var ordered = from name in names
                      orderby name descending
                      select name.ToLower();  //can take custom function / objects as well

        Console.WriteLine("Ordered List (Descending): ");
		foreach (var o in ordered) { Console.Write(o + " "); }
		Console.WriteLine();
	}

	/// <summary>
	/// Palindrome check method. can be pass to linq queries
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	public string IsPalindrome(string input)
	{
		int l = 0; int r = input.Length - 1;

		while (l < r)
		{
			if (input[l] != input[r] ) { return "Not Palindrome"; }
			else { l++; r--; }
		}
		return "Palindrome";
	}

	/// <summary>
	/// To print all Processes
	/// </summary>
	public static void LinqEx1()
	{
		var processes = from p in System.Diagnostics.Process.GetProcesses()          // Type: Process Enumeration
						select new ClassForLinq(p.ProcessName, p.Id);

		foreach(var p in processes)
		{
			Console.WriteLine($"Process Id : {p.Id} , Process Name : {p.Name}");
		}
	}

	/// <summary>
	/// Anonymous DataType
	/// </summary>
    public static void LinqEx2()
    {
        var processes = from p in System.Diagnostics.Process.GetProcesses()          
                        select new { p.ProcessName, p.Id };                         // Microsoft automatically creates a class. objects can be accessed inside the function only. ProcessName and Id are the property of anonymous object(created at backend)

        foreach (var p in processes)
        {
            Console.WriteLine($"Process Id : {p.Id} , Process Name : {p.ProcessName}");
        }
		
    }

    public static void LinqEx3()
    {
		var MaxProcess = System.Diagnostics.Process.GetProcesses().Max(p => p.Id);     // Linq with Lambda Expression
		Console.WriteLine($"Max Process Id: {MaxProcess}");
    }


}

public class ClassForLinq
{
    public string Name; public int Id;

    public ClassForLinq(string Name, int Id)
    {
        this.Name = Name; this.Id = Id;
    }
}


public class ClassRoom
{
	public int Id;
	public decimal Mark1 { get; set; }
	public decimal Mark2 { get; set; }

	public ClassRoom(int Id,decimal Mark1, decimal Mark2)
	{
		this.Id = Id; this.Mark1 = Mark1; this.Mark2 = Mark2;
	}

	
}