using System.Collections.Concurrent;
// using StudentAndSessionsNamespace;
namespace DataNameSpace;

public class MainClass
{
    public static void Main()
    {
        var res = StudentAndSessions.GetDetails();
        System.Console.WriteLine(res);

        foreach (var v in res) {System.Console.WriteLine(v.Id +" "+v.Name +" ");}

        // for(int i =0 ; i<res.Count; i++) {System.Console.WriteLine(res[i]+ " ");}

        System.Console.WriteLine("\n");
        
        var res1 = StudentAndSessions.GetSessionDetails();
        foreach (var v in res1) {System.Console.WriteLine(v.Id +" "+v.Name +" "+v.Details);}

    }   
}