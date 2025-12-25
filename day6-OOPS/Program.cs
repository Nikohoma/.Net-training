using System;
namespace Interface ;

/// <summary>
/// Interface: Must be implemented by the inherited class
/// </summary>
public interface IPrintable
{   
    #region Interface methods
    public void print();

    #endregion
}

public interface IExportable
{
    #region Interface methods
    public void Export();
    #endregion
}


/// <summary>
/// Child Class inheriting multiple Interface
/// </summary>
public class Report : IPrintable, IExportable
{
    #region Declaration
    string Title = String.Empty;
    #endregion

    #region Constructor
    public Report(string Title)
    {
        this.Title = Title;
    }
    #endregion

    #region Interface Functions
    public void print()
    {
        Console.WriteLine($"Interface Print from the class with the Title{Title} ");
    }

    public void Export() {Console.WriteLine("Exported the report successfully");}

    #endregion
}


// Problem Statement: As a HOD, I want to schedule exam to every semester and assign examination for each exam

public abstract class Employee
{
    #region declaration 
    public int id;
    public string name;
    #endregion

    #region Constructor

    public Employee(int id, string name){this.id = id; this.name = name;}

    #endregion

    public abstract void Info();
}

public class HOD: Employee
{

    #region Constructor
    public HOD(int id, string name) : base(id, name){}
    #endregion

 
    public override void Info() {Console.WriteLine($"HOD Id: {id} ; HOD Name: {name}");}


}

public class Examiner : Employee
{
    #region Constructor
    public Examiner(int id, string name) : base(id, name){}
    #endregion

    public override void Info() {Console.WriteLine($"Examiner ID: {id} ; Examiner Name: {name}");}
}

public class Student : Employee
{
    #region Constructor
    public Student (int id, string name) :base(id,name) { this.id = id; this.name = name;}
    #endregion

    public override void Info() {Console.WriteLine($"Student Id: {id} ; Student Name: {name}");}
}

public class Exam : Examiner
{
    #region declarations
    public string ExamName;

    public string ExamDate;

    #endregion

    #region Constructor
    public Exam( string ExamName, string name,  int id, string ExamDate) : base(id, name)
    {this.ExamName = ExamName; this.ExamDate = ExamDate;}

    #endregion

    public void ExamInfo()
    {
        Console.WriteLine($"Exam Name: {ExamName} ; Examiner: {name} ; Exam Date: {ExamDate}");
    }

}

// public class Semester
// {
//     #region declarations
//     int SId;
//     int Snum;
//     #endregion

//     #region Constructor
//     public Semester (int SId, int Snum) { this.SId = SId; this.Snum = Snum;}

//     #endregion
// }


public interface ISemester 
{
    public void semester();
}


public class ExamSchedule : Exam, ISemester
{
    #region declarations
    string RoomNumber;
    #endregion

    #region Constructor
    public ExamSchedule(string ExamName, string name, int id, string ExamDate, string RoomNumber) : base(ExamName, name, id, ExamDate)
    {
        this.RoomNumber = RoomNumber;
    }
    #endregion


    public void semester() {Console.WriteLine("Semester 1 exam schedule: ");}
    public void Examschedule()
    {
        Console.WriteLine($"{ExamName} Exam scheduled in {RoomNumber} on {ExamDate}. {name} would be invigilating.");
    }

}