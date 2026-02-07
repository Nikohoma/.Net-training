using System.Text;

namespace StudentScholarship
{
    // Delegate definition
    public delegate bool IsEligibleforScholarship(Student std);

    /// <summary>
    /// Student Type
    /// </summary>
    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Marks  { get; set;  }
        public char SportsGrade { get; set; }

        // Constructor
        public Student()
        {

        }

        /// <summary>
        /// Method to Retreive only eligible students from the list.
        /// Uses delegate to authenticate
        /// </summary>
        /// <param name="studentsList"></param>
        /// <param name="isEligible"></param>
        /// <returns></returns>
        public static string GetEligibleStudents(List<Student> studentsList, IsEligibleforScholarship isEligible)
        {
            IsEligibleforScholarship eligibility = Program.ScholarshipEligibility;  // Delegate Variable

            List<Student> result = new List<Student>();
            foreach (Student s in studentsList)
            {
                if (eligibility(s)) { result.Add(s); }   // Calling method from delegate variable
            }

            string output = string.Join(", ", result.Select(s=>s.Name));  // Selecting names from the result list and joining them.
            return output;
        }
    }

    /// <summary>
    /// Main Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Method to check eligibility. Delegate method
        /// </summary>
        /// <param name="std"></param>
        /// <returns>boolean</returns>
        public static bool ScholarshipEligibility(Student std)
        {
            if (std.Marks > 80 && std.SportsGrade == 'A')
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // students storage
            List<Student> students = new List<Student>();
            
            // Instances
            Student obj1 = new Student()
            {
                RollNo = 1,
                Name = "Raj",
                Marks = 75,
                SportsGrade = 'A'
            };
            Student obj2 = new Student()
            {
                RollNo = 2,
                Name = "Rahul",
                Marks = 82,
                SportsGrade = 'A'
            };
            Student obj3 = new Student()
            {
                RollNo = 3,
                Name = "Kiran",
                Marks = 89,
                SportsGrade = 'B'
            };
            Student obj4 = new Student()
            {
                RollNo = 4,
                Name = "Sunil",
                Marks = 86,
                SportsGrade = 'A'
            };

            // Adding to the list
            students.Add(obj1);
            students.Add(obj2);
            students.Add(obj3);
            students.Add(obj4);

            // Calling Method to check eligibility
            var output = Student.GetEligibleStudents(students, ScholarshipEligibility);
            Console.WriteLine(output);


        }

    }
}