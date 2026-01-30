using DelegateQuestion;

namespace MainClass
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            #region Delegate Question
            // Student Objects
            Student s1 = new Student()
            {
                Name = "Nikhil",
                Marks1 = 29,
                Marks2 = 30
            };
            Student s2 = new Student()
            {
                Name = "Harsh",
                Marks1 = 25,
                Marks2 = 26
            };
            Student s3 = new Student()
            {
                Name = "Abhinav",
                Marks1 = 21,
                Marks2 = 28
            };

            // to Loop through the StudentDetails List and return their properties. Also call delegate for each objects to print remarks
            foreach (var s in Student.StudentDetails)
            {
                Console.Write($"Student Name: {s.Name} ; Marks1 : {s.Marks1} ; Marks2 : {s.Marks2} ; Total Marks : {s.getTotal()} ; Average Marks : {s.getAverage()} ; Remarks : ");
                Student.Notification(s);
                Console.WriteLine();
            }

            // Delegate Based Functions
            // Actions
            Console.WriteLine("Get Name through Action: ");
            Student.ActionGetName(s1);

            // Func
            Console.WriteLine("Total Marks: ");
            Console.WriteLine(Student.TotalMarks(s1.Marks1, s1.Marks2));

            // Predicate
            Console.WriteLine("Average if more than Threshold? :");
            Console.WriteLine(Student.CheckAverageMoreThanThreshold(s1.getTotal()));

            #endregion





        }
    }
}