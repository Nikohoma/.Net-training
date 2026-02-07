namespace eLearningPlatform
{
    /// <summary>
    /// Course Type
    /// </summary>
    public class Course
    {
        #region Properties
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Instructor { get; set; }
        public int DurationWeeks { get; set; }
        public double Price { get; set; }
        public List<string> Modules { get; set; }
        #endregion

        #region Constructor
        public Course()
        {
        }
        #endregion
    }

    /// <summary>
    /// Enrollment Type
    /// </summary>
    public class Enrollment
    {
        #region Properties
        private static int _counter = 100;
        public int EnrollmentId { get; set; }
        public string StudentId { get; set; }
        public string CourseCode { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public double ProgressPercentage { get; set; } = 0;
        #endregion

        #region Constructor
        public Enrollment()
        {
            EnrollmentId = _counter++;
            EnrollmentDate = DateTime.Now;
            Random random = new Random();
            ProgressPercentage = random.Next(10, 100);  // randomly allocating 
        }
        #endregion
    }

    /// <summary>
    /// Student Progress Class
    /// </summary>
    public class StudentProgress
    {
        #region Properties
        public string StudentId { get; set; }
        public string CourseCode { get; set; }
        public Dictionary<string, double> ModuleScores = new Dictionary<string, double>();
        public DateTime LastAccessed { get; set; }
        #endregion

        #region Constructor
        public StudentProgress()
        {
        }
        #endregion
    }

    /// <summary>
    /// Learning Manger Class with operation methods.
    /// </summary>
    public class LearningManager
    {
        #region Data Storage
        /// <summary>
        /// Data Storage
        /// </summary>
        public List<Course> courses = new List<Course>();
        public List<Enrollment> enrollments = new List<Enrollment>();
        public List<StudentProgress> progress = new List<StudentProgress>();
        #endregion

        #region Methods
        /// <summary>
        /// Method to Add Course into the courses list.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="instructor"></param>
        /// <param name="weeks"></param>
        /// <param name="price"></param>
        /// <param name="modules"></param>
        public void AddCourse(string code, string name, string instructor, int weeks, double price, List<string> modules)
        {
            Course course = new Course()
            {
                CourseCode = code,
                CourseName = name,
                Instructor = instructor,
                DurationWeeks = weeks,
                Price = price,
                Modules = modules
            };
            courses.Add(course);
        }

        /// <summary>
        /// Method to EnrollStudent in existing courses.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseCode"></param>
        /// <returns>boolean</returns>
        public bool EnrollStudent(string studentId, string courseCode)
        {
            foreach (Course c in courses)
            {
                if (c.CourseCode.Trim() == courseCode.Trim())
                {
                    Enrollment enrollment = new Enrollment()
                    {
                        StudentId = studentId,
                        CourseCode = courseCode
                    };
                    enrollments.Add(enrollment);
                    Console.WriteLine($"Student enrolled successfully.");

                    return true;
                }
            }
            Console.WriteLine("Invalid Course");
            return false;
        }

        /// <summary>
        /// Method to update Progress of each student. Validates only course
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseCode"></param>
        /// <param name="module"></param>
        /// <param name="score"></param>
        /// <returns>boolean</returns>
        public bool UpdateProgress(string studentId, string courseCode, string module, double score)
        {
            foreach (Course c in courses)
            {
                if (c.CourseCode == courseCode)
                {
                    StudentProgress studentProgress = new StudentProgress()
                    {
                        StudentId = studentId,
                        CourseCode = courseCode,
                        LastAccessed = DateTime.Now,
                        ModuleScores = { { module,score} }
                    };
                    progress.Add(studentProgress);
                    Console.WriteLine("Student Progress Updated.");

                    return true;
                }
            }
            Console.WriteLine("Cannot Find the specified Course");
            return false;
        }

        /// <summary>
        /// Method to group courses by instructor
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Course>> GroupCoursesByInstructor()
        {
            return courses.GroupBy(c => c.Instructor).ToDictionary(g => g.Key, g => g.ToList());
        }

        /// <summary>
        /// Method to retrieve top performing students.
        /// </summary>
        /// <param name="courseCode"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Enrollment> GetTopPerformingStudents(string courseCode, int count)
        {
            return enrollments.Where(c => c.CourseCode == courseCode).OrderByDescending(e => e.ProgressPercentage).Take(count).ToList();
        }
        #endregion
    }

    /// <summary>
    /// Main Class
    /// </summary>
    public class MainClass
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Instance
            LearningManager lm = new LearningManager();

            // List to store modules which is passed in AddCourse()
            List<string> modules1 = new List<string>();

            modules1.Add("Motion"); modules1.Add("Reflection"); modules1.Add("Oscillations");
            lm.AddCourse("1", "Physics 101", "Newton", 3, 999, modules1);
            // Clearing the modules list for reusing.
            modules1.Clear();
            modules1.Add("Trignometry"); modules1.Add("3-D"); modules1.Add("Probability");
            lm.AddCourse("2", "Maths 101", "Walia", 5, 499, modules1);
            modules1.Clear();
            modules1.Add("Atomic Structure"); modules1.Add("P-Block"); modules1.Add("Nuclear Structure");
            lm.AddCourse("3", "Chemistry 101", "Bohr", 9, 1999, modules1);

            // Enrolling Students in the courses
            lm.EnrollStudent("999", "2");
            lm.EnrollStudent("999", "3");
            lm.EnrollStudent("998", "1");
            lm.EnrollStudent("998", "2");

            // Updating Progress of Student
            lm.UpdateProgress("999", "2", "3-D", 27);
            lm.UpdateProgress("999", "2", "Trignometry", 24);
            lm.UpdateProgress("999", "2", "Probability", 29);

            // Courses grouped by Instructors
            Console.WriteLine("Courses grouped by instructors: ");
            foreach (var k in lm.GroupCoursesByInstructor())
            {
                Console.WriteLine($"Instructor : {k.Key}");
                foreach (var v in k.Value)
                {
                    Console.WriteLine($" --- Course Code : {v.CourseCode} , Course Name : {v.CourseName}");
                }
            }

            // Top Performing Students
            Console.WriteLine("Top Performing Students :");
            foreach (var v in lm.GetTopPerformingStudents("2", 2))
            {
                Console.WriteLine($"Student Id : {v.StudentId} , Progress : {v.ProgressPercentage}");
            }
        }
    }

}