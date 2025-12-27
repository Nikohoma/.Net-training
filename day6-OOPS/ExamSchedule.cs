using System;
namespace ExamScheduler;

// Instances in main class.

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


public class ExamSchedule : Exam
{
    #region declarations
    string RoomNumber; string Semester;
    #endregion

    #region Constructor
    public ExamSchedule(string ExamName, string name, int id, string ExamDate, string RoomNumber, string Semester) : base(ExamName, name, id, ExamDate)
    {
        this.RoomNumber = RoomNumber; this.Semester = Semester;
    }
    #endregion


    public void semester() {Console.WriteLine("Semester 1 exam schedule: ");}
    public void Examschedule()
    {
        Console.WriteLine($"{ExamName} Exam scheduled for {Semester} in {RoomNumber} on {ExamDate}. {name} would be invigilating.");
    }

}