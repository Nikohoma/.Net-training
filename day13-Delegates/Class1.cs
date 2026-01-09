using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Channels;
using System.Xml.Serialization;

namespace day13
{
    /// <summary>
    /// Delegate definition for printing messages
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public delegate string PrintMessage(string message);


    public class PrintingCompany
    {
        /// <summary>
        /// Property to hold a delegate for printing messages
        /// </summary>
        public PrintMessage CustomerChoicePrintMessage { get; set; }

        /// <summary>
        /// Method to print a message using the customer's chosen printing method
        /// </summary>
        /// <param name="message"></param>
        public void PrintMessage(string message)
        {
            string messageToPrint = CustomerChoicePrintMessage(message);
            Console.WriteLine(messageToPrint);
        }

    }

    /// <summary>
    /// Multi-cast delegate example
    /// </summary>
    public class multiCastDelegate
    {
        //Delegate 
        public delegate void myDelegate(string msg);

        // Methods
        public static void MethodA(string msg) => Console.WriteLine("A :" + msg);
        public static void MethodB(string msg) => Console.WriteLine("B :" + msg);
        public static void MethodC(string msg) => Console.WriteLine("C :" + msg);


    }


    /// Do select Test - Person Details
    public class Person
    {
        #region Properties
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        #endregion

        #region Constructor
        public Person()
        {

        }

        #endregion
    }

    public class PersonImplementation
    {
        /// <summary>
        /// Method to get names and addresses from a list of Person objects
        /// </summary>
        /// <param name="person"></param>
        public void GetName(IList<Person> person) 
        { 
            foreach(var p in person)
            {
                Console.Write($"{p.Name} {p.Address} ");
                
            }
        }

        /// <summary>
        /// Method to calculate Average age from a list of Person objects
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public double Average(IList<Person> person) 
        {
            double sumofAge = 0;
            foreach(var p in person)
            {
                sumofAge += p.Age;
            }
            Console.WriteLine();
            return Math.Round(sumofAge / person.Count,2);
        }

        /// <summary>
        /// Method to calculate Maximum age from a List of Person objects
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public int Max(IList<Person> person)
        {
            int max = 0;
            foreach(var p in person)
            { 
                if (p.Age > max) { max = p.Age; }
            }
            return max;
        }

        /// <summary>
        /// Method to calculate Second Highest age from a List of Person objects
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public int SecondHighest(IList<Person> person)
        {
            int highest = 0; 
            foreach(var p in person)
            {
                if (p.Age > highest) { highest = p.Age; }
            }
            int secondHighest = 0;
            foreach(var p in person)
            {
                if (p.Age > secondHighest && p.Age < highest) { secondHighest = p.Age; }
            }
            return secondHighest;

            //emp.OrderByDescending(n => n.Id).Skip(1).FirstOrDefault(); LINQ Method
        }

    }


    // Do-Select Test - Method Overloading
    public class Source
    {
        /// <summary>
        /// Method to add three integers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        /// <summary>
        /// Method to add three double values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public double Add(double a, double b, double c)
        {
            return a + b + c;
        }
    }

    /// <summary>
    /// Meeting Question - Employee Class
    /// </summary>
    public class Employee
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        public Employee(int Id, string Name, double Salary)
        {
            this.Id = Id; this.Name = Name; this.Salary = Salary;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method to display the Employee details.
        /// </summary>
        public void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Salary: {Salary}");
        }


        #endregion


    }

}
