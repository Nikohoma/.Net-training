using MultipleInheritence1;
using Ques1;
using CRM;

public class MainClass
{
    public static void Main()
    {
    
    #region Instances

    if (false){
    
    #region Multiple Inheritence Instances

    Bird bird1 = new Bird();
    bird1.Sing();

    Bird bird2 = new Bird();
    bird2.Walk();

    Ibird1Char bird3 = new Bird();
    bird3.Fly();

    Ibird2Char bird4 = new Bird();
    bird4.Fly();
    #endregion

    #region Reference Usage Instances

    Refer refer = new Refer();
    int x = 10; int y = 5;  // Reference parameter should be initialised before calling
    refer.Method1(ref x, ref y);
    Console.WriteLine($"Int x = {x}");
    Console.WriteLine($"Int y : {y}");


    int num1 = int.MaxValue ; int num2 = 1;
    int output = refer.Add(num1, num2);
    Console.WriteLine(output);

    Refer obj = new Refer();
    int Square;
    int Half;
    obj.add1(5, out Square, out Half);

    #endregion

    //Scenario based question instances
    #region  Robot Hazard Risk Score Instances

    RobotHazardAuditor calc = new RobotHazardAuditor();
    Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
    double Armprecision = Double.Parse(Console.ReadLine());
    Console.WriteLine("Enter Worker Density (1-20):");
    int WorkerDensity = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter Machinery State:");
    string MachineryState = Console.ReadLine();

    string res = calc.CalculateHazardRisk(Armprecision,WorkerDensity,MachineryState);
    Console.WriteLine(res);

    #endregion

    #region Arrays - Jagged 

    int[][] data = new int[4][];
    data[0] = new int[] { 1, 2, 3 };
    data[1] = new int[] { 10, 20 };
    data[2] = new int[] { 7, 8, 9, 10 };
    data[3] = new int[] {123,43,2,1,2,3,4};


    for (int i = 0; i < data.Length; i++)
    {
        Console.Write("Row " + i + ": ");
        foreach (var v in data[i]) Console.Write(v + " ");
        Console.WriteLine();
    }  

    #endregion


    #region Generics Instance

    Console.WriteLine("Generics output below \n");

    collections coll = new collections();
    coll.sample();

    #endregion

    }

    #region CRM Instances
    
    Suspect suspect = new Suspect(1, "New Delhi", "2138973282");
    suspect.Info();

    Prospect prospect = new Prospect(2,"Noida", "7218392910","Flat 20% Off on electronics",20);
    prospect.Info();

    Account account = new Account(3, "Dehradun", "1298391283", "Likes the Product", false);
    account.Info();

    #endregion

    #endregion


    }
}