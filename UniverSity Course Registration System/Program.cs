using System;
using System.Collections.Generic;
using System.Linq;

namespace University_Course_Registration_System
{
     // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                try
                {
                    // TODO:
                    // Implement menu handling logic using switch-case
                    // Prompt user inputs
                    // Call appropriate UniversitySystem methods
                    switch (choice)
                    {
                        case "1":
                            global::System.Console.WriteLine("Enter Course Code: ");
                            string code = Console.ReadLine();
                            global::System.Console.WriteLine("Enter Course Name: ");
                            string name = Console.ReadLine();
                            global::System.Console.WriteLine("Enter Credits: ");
                            int credits = int.Parse(Console.ReadLine());
                            global::System.Console.WriteLine("Enter Max Capacity: ");
                            int maxCapacity = int.Parse(Console.ReadLine());
                            List<string> prerequisites = new List<string>();
                            global::System.Console.WriteLine("Enter prerequisites: ");
                            string prq = Console.ReadLine();
                            string[] parts = prq.Split(" ");
                            foreach(var p in parts) { prerequisites.Add(p); }
                            system.AddCourse(code, name, credits, maxCapacity, prerequisites);
                            break;
                        case "2":
                            //string id, string name, string major, int maxCredits = 18, List< string > completedCourses = null
                            global::System.Console.WriteLine("Enter Student Id: ");
                            string id = Console.ReadLine();
                            global::System.Console.WriteLine("Enter Student Name: ");
                            string name = Console.ReadLine();
                            global::System.Console.WriteLine("Enter Major: ");
                            int major = int.Parse(Console.ReadLine());
                            global::System.Console.WriteLine("Enter Max Credits: ");
                            int maxCredits = int.Parse(Console.ReadLine());
                            List<string> completeCourses = new List<string>();
                            global::System.Console.WriteLine("Enter prerequisites: ");
                            string cc = Console.ReadLine();
                            string[] parts = cc.Split(" ");
                            foreach (var p in parts) { completeCourses.Add(p); }
                            system.AddStudent(id, name, major, maxCredits, completeCourses);
                            break;
                        case "3":
                            global::System.Console.WriteLine("Enter Student Id : ");
                            string studentId = Console.ReadLine();
                            global::System.Console.WriteLine("Enter Course Code : ");
                            string courseCode = Console.ReadLine();
                            system.RegisterStudentForCourse(studentId, courseCode);
                            break;
                        case "4":
                            global::System.Console.WriteLine("Enter Student Id : ");
                            string studentId = Console.ReadLine();
                            global::System.Console.WriteLine("Enter Course Code : ");
                            string courseCode = Console.ReadLine();
                            system.DropStudentFromCourse(studentId,courseCode);
                            break;
                        case "5":
                            system.DisplayAllCourses();
                            break;
                        case "6":
                            global::System.Console.WriteLine("Enter Student Id : ");
                            string studentId = Console.ReadLine();
                            system.DisplayStudentSchedule(studentId);
                            break;
                        case "7":
                            system.DisplaySystemSummary();
                            break;
                        case "8":
                            exit = true;
                            return;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

