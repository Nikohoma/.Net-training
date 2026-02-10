using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // Student Class
    // =========================
    public class Student
    {
        public string StudentId { get; private set; }
        public string Name { get; private set; }
        public string Major { get; private set; }
        public int MaxCredits { get; private set; }

        public List<string> CompletedCourses { get; private set; }
        public List<Course> RegisteredCourses { get; private set; }

        public Student(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            StudentId = id;
            Name = name;
            Major = major;
            MaxCredits = maxCredits;
            CompletedCourses = completedCourses ?? new List<string>();
            RegisteredCourses = new List<Course>();
        }

        public int GetTotalCredits()
        {
            // TODO: Return sum of credits of all RegisteredCourses
            return RegisteredCourses.Sum(c => c.Credits);
        }

        public bool CanAddCourse(Course course)
        {
            // TODO:
            // 1. Course should not already be registered
            // 2. Total credits + course credits <= MaxCredits
            // 3. Course prerequisites must be satisfied
            foreach(var c in RegisteredCourses)
            {
                if (c.CourseCode == course.CourseCode)
                {
                    return false;
                }
            }
            var totalCredits = RegisteredCourses.Sum(c => c.Credits);
            if (course.Credits + totalCredits > MaxCredits)
            {
                return false;
            }
            if (!course.HasPrerequisites(CompletedCourses))
            {
                return false;
            }
            else { return true; }

        }

        public bool AddCourse(Course course)
        {
            // TODO:
            // 1. Call CanAddCourse
            // 2. Check course capacity
            // 3. Add course to RegisteredCourses
            // 4. Call course.EnrollStudent()
            if (CanAddCourse(course))
            {
                if (!course.IsFull())
                {
                    RegisteredCourses.Add(course);
                    course.EnrollStudent();
                    return true;
                }
            }
            global::System.Console.WriteLine("Cannot Add Course.");
            return false;

        }

        public bool DropCourse(string courseCode)
        {
            // TODO:
            // 1. Find course by code
            // 2. Remove from RegisteredCourses
            // 3. Call course.DropStudent()
            Course courseToRemove = null;
            foreach(var c in RegisteredCourses)
            {
                if (c.CourseCode.ToLower().Trim() == courseCode.ToLower().Trim())
                {
                    courseToRemove = c;
                    break;
                }
            }
            if (courseToRemove != null) { courseToRemove.DropStudent();  RegisteredCourses.Remove(courseToRemove); return true; }
            else { return false; }
        }

        public void DisplaySchedule()
        {
            // TODO:
            // Display course code, name, and credits
            // If no courses registered, display appropriate message
            if (RegisteredCourses.Count == 0)
            {
                global::System.Console.WriteLine("Not Registered for any course.");
            }
            else 
            {
                foreach(var c in RegisteredCourses)
                {
                    global::System.Console.WriteLine($"Course Code : {c.CourseCode}, Course Name : {c.CourseName}, Credits : {c.Credits}.");
                }
            }
        }



    }
}
