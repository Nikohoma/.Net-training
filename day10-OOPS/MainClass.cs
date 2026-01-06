using System.Text.RegularExpressions;
using day10;



public class MainClass
{
    public static void Main()
    {   
        #region Extension Function
        string s = "ABca";
        System.Console.WriteLine(s.CheckPalindrome());
        #endregion

        #region Regex

        // Declaring Input and pattern for regex
        System.Console.WriteLine("\nRegex Check: ");
        string input = "ERROR: TIMEOUT while calling an API";
        string pattern = @"timeout";

        // Custom declaration for regex
        var rx = new Regex(
            pattern, RegexOptions.IgnoreCase,
            TimeSpan.FromMilliseconds(100)      // If given 0.5ms, code will not even reach the input and throws RegexMatchTimeoutException
        );
        Console.WriteLine(rx.IsMatch(input) ? "Error Found" : "No Error");

        #endregion

        #region GC
        // System.Console.WriteLine("Garbage Collection \n");
        // var list = new List<byte[]>();
        // for (int i =0; i<20000; i++)
        // {
        //     list.Add(new byte[1024]); //many allocations
        //     System.Console.WriteLine("Allocated");
        //     System.Console.WriteLine("Total Memory: "+GC.GetTotalMemory(forceFullCollection: false));
        // }

        // GC.Collect();   // Empty the GC
        System.Console.WriteLine(GC.CollectionCount(0));
        System.Console.WriteLine(GC.GetTotalMemory(forceFullCollection: false));
        var x = new List<long>();
        for (int i =0 ; i <20300; i++){x.Add(i);}
        System.Console.WriteLine(GC.GetTotalMemory(forceFullCollection: false));
        GC.Collect();
        System.Console.WriteLine(GC.GetTotalMemory(forceFullCollection: false));

        #endregion


        #region GC with autodispose Class

        System.Console.WriteLine("Garbage Collector Class Begins \n");
        Garbage garbage = new Garbage();
        try
        {
            for(int i =0; i<10;i++) {garbage.Names.Add(i.ToString());}
            System.Console.WriteLine("ArrayList: \n");
            foreach(var v in garbage.Names) {System.Console.Write(v + " ");}
        }
        catch(Exception e) {System.Console.WriteLine($"Error: {e.Message}");}
        finally
        {   System.Console.WriteLine("\nEmptying Garbage Collector...");
            garbage.Dispose();
        }

        #endregion


        #region 
        System.Console.WriteLine("Custom Collection \n");

        CustomCollection cc = new CustomCollection();
        cc.Add("A");cc.Add("B");
        System.Console.WriteLine(cc.Find("A"));




        #endregion




    }
}