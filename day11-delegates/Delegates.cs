using System;
using System.Collections.Generic;
using System.Text;

namespace DataSerialization
{
    /// <summary>
    /// Data Serialization Class (XML)
    /// </summary>
    public class Student
    {
        #region Properties
        public int Id { get; set; }
        public string? Name { get; set; }
        public int[]? Scores { get; set; }
        public List<string>? Subjects { get; set; }

        #endregion

        #region Non Parameterised constructor: Should be non parameterised for XML Serialization
        public Student()
        {
            
        }
        #endregion
    }


    /// Delegate 

    public delegate int DelegateAddFunction(int a, int b);   // Delegate Method Signature
    public class ExampleOfDelegate
    {
        #region Fields
        public int a; public int b;
        #endregion

        // Method that implements the delegate signature
        public void DelegateEx1()
        {
            DelegateAddFunction delegateVariable = new DelegateAddFunction(AddMethod1);      // Create a delegate instance and point it to the method.
            Console.WriteLine("Sum : "+delegateVariable(1, 2)); 
        }

        /// <summary>
        /// Method to be called by delegate
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int AddMethod1(int a, int b)
        {
            return a + b;
        }
    }


    public class SubtractionClass
    {
        public void SubtractionMethod(int a, int b) 
        {
            DelegateAddFunction SubtractionVariable = new DelegateAddFunction(Subtract);
            Console.WriteLine($"Subtraction : {SubtractionVariable(a,b)}");
        }

        private int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}
