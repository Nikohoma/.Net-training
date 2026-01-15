namespace MainClass;

using AnotherNamespace;
using LinqGenericV2;
using OneMoreNamespace;
using System.Threading;
using ThreadingExamples;
using static ThreadingExamples.Threading;

public class MainClass
{
    public static async Task Main(string[] args)      // Caller Method shoudld be async Task to call async await methods
    {
        #region LinqGenericExample
        LearnLinq.RunDemo();
        #endregion

        #region T Place holder

        Object obj = new Object();
        MyGlobalType<Object> gt = new MyGlobalType<Object>();

        Console.WriteLine("Data Type : "+gt.GetDataType(obj)); 

        List<UGStudent> students = new List<UGStudent>();

        Console.WriteLine(gt.GetDataType("Students Data Type: " + students));
        #endregion

        #region Special delegates
        SpecialDelegates sd = new SpecialDelegates();
        //sd.RunActions();
        //sd.RunPredicate();
        //sd.RunFunction();
        //#endregion

        //#region Threading 
        //Console.WriteLine("Threading Outputs: \n");
        //Threading.Run1();

        //Console.WriteLine("\nMulti threading Outputs");
        //Thread t1 = new Thread(Threading.Task1);
        //Thread t2 = new Thread(Threading.Task2);
        //t1.Start();
        //t1.Join();  // Wait for t1 to complete
        //t2.Start();


        Console.WriteLine("\nAsync Method: ");
        Threading t = new Threading();
        await t.CallMethod();
        #endregion

        #region File Handling
        Console.WriteLine("File Handling Outputs: ");
        FileHandling fh = new FileHandling();
        fh.WriteFile();
        fh.ReadFile();

        #endregion
    }
}