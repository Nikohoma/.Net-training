using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateQuestion
{

    public delegate void Notify(string message);  // Delegate declaration

    public class Student
    {
        /// <summary>
        /// Properties of Student
        /// </summary>
        public string Name { get; set; }
        public decimal Marks1 { get; set; }
        public decimal Marks2 { get; set; }

        public static List<Student> StudentDetails = new List<Student>();    // To Store Student Objects
        public string Message { get; private set; } = "";

        // Constructor
        public Student()
        {
            StudentDetails.Add(this);
        }


        /// <summary>
        /// Method to return details stored in the list
        /// </summary>
        /// <returns></returns>
        public List<Student> Details()
        {
            return StudentDetails;
        }

        /// <summary>
        /// Method to get Average Marks of the Student
        /// </summary>
        /// <returns></returns>
        public decimal getAverage()
        {
            return (Marks1 + Marks2) / 2;
        }

        /// <summary>
        /// Method to get total marks of the student
        /// </summary>
        /// <returns></returns>
        public decimal getTotal()
        {
            return Marks1 + Marks2;
        }

        // Method for delegate
        public static void CheckAverageAndNotify(string message)
        {
            Console.WriteLine(message);
        }

        // Method to invoke delegate if the condition is met
        public static void Notification(Student student)
        {
            Notify notify = CheckAverageAndNotify;

            if (student.getAverage() < 25)
            {
                notify($"{student.Name} needs improvement");
            }
            else
            {
                notify($"{student.Name} have done well.");
            }
        }

        // Delegate based Functions : Conditions/Logic stored in a variable, Can be passed as a parameter
        // Action Delegate : Takes input and returns void ;  Structure : Action<inputType> ActionName = LambdaExpression ; Call from Main
        public static Action<Student> ActionGetName = s =>
        {
            Console.WriteLine(s.Name);
        };

        // Predicate : Take one input and returns bool
        public static Predicate<decimal> CheckAverageMoreThanThreshold = x => x > 25;    // Structure : Predicate<inputType> PredicateName = lambdaExpression on input
       

        // Func Delegate : takes multiple inputs and return a value
        public static Func<decimal, decimal, decimal> TotalMarks = (m1, m2) => m1 + m2;   // Structure : Func<inputType,inputType,outputType> Funname = lambdaExpression (anonymous inputs => Operation on anonymous inputs)
       



    }
}
