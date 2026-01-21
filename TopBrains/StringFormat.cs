using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace StringFormat
{
    /// <summary>
    /// Student data type
    /// </summary>
    public class Student
    {
        // Properties 
        public string Name { get; set; }
        public int Marks { get; set; }

        // Constructor 
        public Student(string Name, int Marks)
        {
            this.Name = Name; this.Marks = Marks;
        }
    }

    /// <summary>
    /// Class to store valid Student data type into the list and Print the copy of the list.
    /// </summary>
    public class StringFormat
    {
        private List<Student> _students = new List<Student>();  // List to store all records 

        /// <summary>
        ///  Method to Input valid Students into the list. and return the list in Json Format
        /// </summary>
        /// <param name="input"></param>
        /// <param name="minScore"></param>
        public void Records(string[] input, int minScore) 
        { 
            foreach (var s in input)
            {
                string[] parts = s.Split(':'); // Splitting and storing into a string arr.
                string name = parts[0].ToString(); int marks = int.Parse(parts[1].Trim()); 
                if (marks >= minScore)
                {
                    _students.Add(new Student(name, marks));
                }
            }
            // Returning copy of the list ordered by marks and name.
            Console.WriteLine("Records in JSON Format : "+JsonSerializer.Serialize(new List <Student>(_students.OrderByDescending(x=>x.Marks).ThenBy(y=>y.Name))));
        }


    }
    
    /// <summary>
    /// Main Class
    /// </summary>
    public class MainClass
    {
        public static void Main(string[] args)
        {
            StringFormat s = new StringFormat();
            string[] input = ["Nikhil : 25", "Punya : 30 ", "Yashika : 29"];
            s.Records(input,28);
        }
    }
}
