namespace StudentAndSessionsNamespace;
using StudentNameSpace;
using StudentSessionsNamespace;


/// <summary>
/// To store the list of student in a particular session
/// </summary>

public class StudentAndSessions
{
    #region declarations
    public List<Student>? Students {get; set;}
    public StudentSessions? session {get; set;}

    #endregion


    #region  Constructor
    public  StudentAndSessions()
    {
    }

    #endregion



}