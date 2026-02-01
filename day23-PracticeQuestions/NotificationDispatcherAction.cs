using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateBasedFunctions
{
    /// <summary>
    /// Scenario: You are building a system that processes orders. 
    /// Once an order is processed, you need to perform various "side effects" like printing a receipt or sending an email. 
    /// Create a generic method ProcessTask<T> that takes an item and an Action to perform on that item.
    /// </summary>
    public class NotificationSystem
    {
        public void ProcessTask<T>(T item, Action<T> action)
        {
            Console.WriteLine("Initializing Process: ");
            action(item);
            Console.WriteLine("Process Completed");
        }
    }

    ///Scenario: You have a list of various objects (Products, Users, etc.). 
    ///Write a generic method FilterData<T> that accepts a List<T> and a Predicate<T>, returning a new list containing only the items that match the criteria.
    public class GenericDataFilter
    {
        public List<T> FilterData<T>(List<T> items, Predicate<T> Condition)
        {
            List<T> result = new List<T>();
            
            foreach(var item in items)
            {
                if (Condition(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }

}
