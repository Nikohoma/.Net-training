using MVCwithEF.Models;

namespace MVCwithEF.Data
{
    public class StudentData
    {
        private static List<Student> _students { get; set; } = new List<Student>();

        static StudentData()
        {
            _students.Add(new Student(1, "A", 23, 43));
            _students.Add(new Student(2, "B", 33, 47));
            _students.Add(new Student(3, "C", 13, 35));
            _students.Add(new Student(4, "D", 34, 15));
        }

        public static List<Student> GetStudents()
        {
            return _students.AsReadOnly().ToList();
        }
    }
}
