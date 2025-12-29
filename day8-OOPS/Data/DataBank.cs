using StudentNameSpace;
namespace DataNameSpace;
using StudentSessionsNamespace;
using StudentAndSessionsNamespace;



/// <summary>
/// Seperate class to get the list of students. Using static for inline.
/// </summary>


public static class StudentAndSessions
{
    #region declarations
    public static List<Student> StudentsList =new List<Student>();

    public static List<StudentSessions> SessionsList = new List<StudentSessions>();

    #endregion


    #region Static Constructor
    static StudentAndSessions()
    {
        StudentsList.Add(new Student() {Id=1,Name="A"});
        StudentsList.Add(new Student() {Id=2,Name="B"});
        StudentsList.Add(new Student() {Id=3,Name="C"});
        StudentsList.Add(new Student() {Id=4,Name="D"});

        SessionsList.Add(new StudentSessions() {Id = 1, Name ="A", Details = "CSE201"});
        SessionsList.Add(new StudentSessions() {Id = 2, Name ="B", Details = "CSE202"});
        SessionsList.Add(new StudentSessions() {Id = 3, Name ="C", Details = "CSE203"});

    }


    #endregion

    public static List<Student> GetDetails(){return StudentsList;}

    public static List<StudentSessions> GetSessionDetails() {return SessionsList;}

    

}