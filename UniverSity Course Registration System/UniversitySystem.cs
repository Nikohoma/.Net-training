using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            // TODO:
            // 1. Throw ArgumentException if course code exists
            // 2. Create Course object
            // 3. Add to AvailableCourses
            if (AvailableCourses.ContainsKey(code))
            {
                throw new ArgumentException("Course is already available.");
            }
            Course course = new Course(code, name, credits, maxCapacity, prerequisites);
            AvailableCourses.Add(code,course);
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            // TODO:
            // 1. Throw ArgumentException if student ID exists
            // 2. Create Student object
            // 3. Add to Students dictionary
            if (Students.ContainsKey(id))
            {
                throw new ArgumentException("Student already present.");
            }
            Student student = new Student(id, name, mahor, maxCredits, completedCourses);
            Students.Add(student);
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student and course existence
            // 2. Call student.AddCourse(course)
            // 3. Display meaningful messages
            if (Students.ContainsKey(studentId) && AvailableCourses.ContainsKey(courseCode))
            {
                var student = Students[studentId];
                var course = AvailableCourses[course];
                student.AddCourse(studentId,course);
                global::System.Console.WriteLine("Course assigned to Student.");
                return true;
            }
            else
            {
                Console.WriteLine("Check Student Id or Course Code");
                return false;
            }

        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student existence
            // 2. Call student.DropCourse(courseCode)
            if (Students.ContainsKey(courseCode))
            {
                Students[studentId].DropCourse(courseCode);
                return true;
            }
            else
            {
                global::System.Console.WriteLine("Student does not exist.");
                return false;
            }
        }

        public void DisplayAllCourses()
        {
            // TODO:
            // Display course code, name, credits, enrollment info
            foreach(var course in AvailableCourses)
            {
                global::System.Console.WriteLine($"Course Code : {course.CourseCode}, Course Name : {course.CourseName}, Credits : {course.Credits}, Total Enrolled : {course.CurrentEnrollment}.");
            }
        }

        public void DisplayStudentSchedule(string studentId)
        {
            // TODO:
            // Validate student existence
            // Call student.DisplaySchedule()
            if (Students.ContainsKey(studentId))
            {
                Student[studentId].DisplaySchedule();
            }
            else
            {
                throw new Exception("Student does not exist.");
            }
        }

        public void DisplaySystemSummary()
        {
            // TODO:
            // Display total students, total courses, average enrollment
            var totalStudents = Students.Count;
            var totalCourses = AvailableCourses.Count;
            var averageEnrollment = (double)totalStudents / totalCourses;
            global::System.Console.WriteLine($"Total Students : {totalStudents}\nTotalCourses : {totalCourses}\nAverage Enrollment : {averageEnrollment}.");
        }
    }
}
