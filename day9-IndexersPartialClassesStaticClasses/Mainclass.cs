using System.Runtime.InteropServices;
using Classes;

public class MainClass
{
    public static void Main()
    {   
        #region Instances

        #region Indexers
        // Indexers i1 = new Indexers();

        // // Setting Values
        // i1[0] = "A";
        // i1[1] = "B";

        // //Getting Values
        // Console.WriteLine("First Value : "+i1[0]);
        // Console.WriteLine("Second Value: "+i1[1]);

        Student s1 = new Student();
        s1.RNo = 1; s1.Name = "Nikhil"; s1[0]= "Volume 1"; s1[1]= "Volume 2"; s1[2] = "Volume 3"; s1.SetAddress("New Delhi");

        System.Console.WriteLine($"Student Info: Name = {s1.Name}, RollNo. = {s1.RNo}, Courses = {s1[0]}, {s1[1]}, {s1[2]}, City : {s1.Address}");

        #endregion

        #region Partial Classes Instances
        System.Console.WriteLine("\n Partial Classes Instances \n");

        Student1 pc = new Student1(1);
        pc.Info();

        Student1 s2 = new Student1(2);
        s2.Name = "Abord";
        s2.Info1();

        #endregion

        #region Static
        // GeneralUses gu = new GeneralUses(); // Can't create the object of static class

        GeneralUses.GetRno();
        GeneralUses.GetRno();

        string s = "string is not empty";
        System.Console.WriteLine("\n WordLength: ");
        Console.WriteLine(s.WordLength());

        #endregion


        #endregion
    }
}