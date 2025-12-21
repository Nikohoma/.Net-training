using System.ComponentModel;

public class Student
{

    //Property : Wrapper around fields
    // public int id{get; set;}
    // public string Name{get;set}
    // public string Feedback{get;} //Cannot change the feedback now

    #region Fields Declaration
    public int id;
    public string name;
    public int age;
    #endregion

    #region Constructor
    public Student(int id, string name, int age)   // rather than passing parameters, i can pass the field inside the constructor directly.
    {
        this.id = id;
        this.name = name;
        this.age = age;

    }
    #endregion

    #region Member Function
    public void Displaydetails()
    {
        Console.WriteLine("ID of the Student: "+id);
        Console.WriteLine("Name of the Student: "+name);
        Console.WriteLine("Age of the Student: "+age);

    }
    #endregion
}


#region Another Class
public class StudentV1
{

    #region Declaration
    public int id1;
    public string name1;
    public int age1;
    #endregion


    #region Constructor
    public StudentV1()  //Params not define so user can make empty objects which would waste memory. Therefore to save memory, we define params inside the constructor like above class example.
    {
        id1 = 0;
        name1 = String.Empty;
    }
    #endregion
    

    #region Member Function
    public string DisplayInfo()
    {
        return  "Id: "+id1 + "; Name: "+name1+ "; Age: "+age1;
    }
    #endregion

}
#endregion


public class Employee
{
    #region Declarations
    public int EmpId;
    public string EmpName;
    #endregion

    #region Constructor
    public Employee()
    {
        EmpId=0;
        EmpName=String.Empty;
        
    }
    #endregion

    #region Member Function
    public string GetEmployeeDetails()
    {
        return " Employee Id: "+EmpId+"; Employee Name: "+EmpName;
    }
    #endregion
}

public class Competitions
{
    #region Declarations
    public int CompetitionId ;
    public string CompetitionName;
    public double PrizeMoney;
    #endregion

    #region Constructor
    public Competitions()
    {
        CompetitionId = 0;
        CompetitionName = String.Empty;
        PrizeMoney = 0;
    }
    #endregion

    #region Member Function
    public string GetCompetitionDetails()
    {
        return "Competition Id : "+CompetitionId+"; Competition Name: "+CompetitionName + "; Prize Money: "+PrizeMoney;
    }
    #endregion
}

public class Results
{
    #region Declarations
    public int CompetitionId;
    public int[] Winners;
    #endregion
    
    #region Constructors
    public Results(int CompetitionId, int[] Winners)   //Adding params so that user cannot create empty object
    {
        // CompetitionId = 0;
        // Winners = [];
        this.CompetitionId = CompetitionId;
        this.Winners = Winners;
    }
    #endregion

    #region Member Function
    public void DisplayResults()
    {
        Console.WriteLine("Competition Id: "+CompetitionId);
        Console.WriteLine("Number of Winners: "+Winners.Length);
    }
    #endregion



}


public class UGStudents
{
    #region Declaration
    public int UGid;
    public string UGname;
    #endregion
    
    #region Constructor
    public UGStudents(int UGid, string UGname)
    {
        this.UGid = UGid;
        this.UGname = UGname;
    }
    #endregion 

    #region Member Function
    public string DisplayUGStudentsDetails()
    {
        return "UG Student Id: "+UGid+"; UG Student Name: "+UGname;
    }

    #endregion

}

public class PGStudents
{
    #region Declarations
    public int PGId;
    public string PGname;
    #endregion

    #region Constructor
    public PGStudents(int PGId, string PGname)
    {
        this.PGId = PGId;
        this.PGname = PGname;
    }
    #endregion

    #region Member Function
    public string DisplayPGStudents()
    {
        return "PG Student ID: "+PGId+"; PG Student Name: "+PGname;
    }
    #endregion

}

#region Inheritence Classes
public class Person
{
    #region Declaration
    public int id {get; set;}       //another way of declaring, just a wrapper around fields
    public string name {get; set;}
    public int age {get; set;}
    #endregion

    #region Constructor
    public Person(int id, string name, int age)
    {
        this.id = id; this.name=name ; this.age = age;
    }
    #endregion
}

public class Man : Person           //Inheriting Person class
{
    #region Declaration
    public string Playing {get; set;}   //No need to add Person declaration since inheriting
    #endregion

    #region Constructor
    public Man(int id, string name, int age, string Playing) : base(id,name,age)  // Need to define all parameters with the base(parent) params.
    {
        this.Playing = Playing;
    }
    #endregion

    
}

public class Woman : Person
{

    #region Declaration
    public string NotPlaying {get; set;}
    #endregion

    #region Constructor
    public Woman(int id, string name, int age, string NotPlaying) : base(id,name,age)
    {
        this.NotPlaying = NotPlaying;
    }
    #endregion
    
}
#endregion





public class Program
{
    // Main Function
    static void Main()
    {
        #region Instances of Class Student
        // //Creating Object
        // Student s1 = new Student(1,"Nikhil",24); 

        // //Calling the method
        // s1.Displaydetails();
        // #endregion

        // #region Instances of Class StudentV1
        // StudentV1 s2 = new StudentV1();
        // s2.id1 = 0;
        // s2.name1 = "Krako";
        // s2.age1 = 23;

        // Console.WriteLine(s2.DisplayInfo());
        #endregion

        #region Instances of Class Employee
        Employee e1 = new Employee(); 
        e1.EmpId = 1; e1.EmpName = "A";

        Employee e2 = new Employee(); 
        e2.EmpId = 2; e2.EmpName = "B";

        Employee e3 = new Employee(); 
        e3.EmpId = 3; e3.EmpName = "C";
        #endregion

        #region Instances of Class Competitions
        Competitions c1 = new Competitions();
        c1.CompetitionId = 1; c1.CompetitionName = "Comp1"; c1.PrizeMoney = 10000;

        Competitions c2 = new Competitions();
        c2.CompetitionId = 2; c2.CompetitionName = "Comp2"; c2.PrizeMoney = 20000;

        Competitions c3 = new Competitions();
        c3.CompetitionId = 3; c3.CompetitionName = "Comp3"; c3.PrizeMoney = 30000;

        #endregion

        #region Instances of Results
        int[] Winners = {e1.EmpId, e2.EmpId};

        Results res1 = new Results(c1.CompetitionId, Winners);
        res1.CompetitionId = c1.CompetitionId;
        res1.Winners = Winners;
        res1.DisplayResults();

        #endregion

        #region Instances of UG Students
        UGStudents ug1 = new UGStudents(1,"A");
        Console.WriteLine(ug1.DisplayUGStudentsDetails());
        #endregion

        #region Instances of PG Students
        PGStudents pg1 = new PGStudents(2, "B");

        Console.WriteLine(pg1.DisplayPGStudents());
        #endregion

        
        #region Inheritence
        Program program = new Program(); //To call the softfunction defined in the Program class.

        // Person instance
        Person person = new Person(1,"A",21);

        Console.WriteLine(program.GetDetails(person)); //Calling the function with the person parameters.
        // string output = program.GetDetails(person);  //Calling the function with the person parameters.
        // Console.WriteLine(output);

        //Man instance
        Man man = new Man(2,"M",23,"Football");
        string output1 = program.GetDetails(man);
        Console.WriteLine(output1);

        //Woman instance
        Woman woman = new Woman(3,"W",22,"Baseball");
        string output2 = program.GetDetails(woman);
        Console.WriteLine(output2);

        #endregion


    }


    #region (runtime Polymorphism) Function for Inheritence: defined for parent class, Common function that can be called for all inheritedely connected classes
    public string GetDetails(Person person)
    {
        if (person is Man) // If man object instead of person since all arguments are not same for man and person class
        {
            Man man = (Man) person;
            return $"Man Id: {man.id}; Man Name: {man.name}; Man Age: {man.age}; Playing: {man.Playing}";
        }

        if (person is Woman woman) // is used for pattern matching: Check if the object is of specific type
        {
            // Woman woman = (Woman) person; //Just pass the Woman object while pattern matching
            return $"Woman Id: {woman.id}; Woman Name: {woman.name}; Woman Age: {woman.age}; NotPlaying: {woman.NotPlaying}";
        }
        
        return $"Person Id: {person.id}; Person Name: {person.name}; Person Age: {person.age}";  // To print common parameters among Person, Man, Woman.
    }
    #endregion



}