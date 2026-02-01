using DelegateQuestion;
using DelegateBasedFunctions;
using BikeRentalSystem;

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

            #region DelegateBasedFunctions

            Console.WriteLine("\n==========================DelegateBasedFunctions Outputs=============================");
            Console.WriteLine("Notification System Output: ");
            NotificationSystem ns = new NotificationSystem();
            ns.ProcessTask("Order #121", msg => Console.WriteLine($"Email Sent : {msg} placed" ));
            ns.ProcessTask("Order #121", msg => Console.WriteLine($"SMS Sent : {msg} placed" ));

            Console.WriteLine("\nGeneric Data Filter Output: ");
            GenericDataFilter filter = new GenericDataFilter();
            List<int> items = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var filteredResult = filter.FilterData(items, i => i % 2 == 0);
            foreach (var f in filteredResult)
            {
                Console.Write(f+" ");
            }
            #endregion

           


        }
    }
}