using System;
using System.Collections.Generic;
using System.Text;
namespace Events;

/// <summary>
/// Events.
/// Steps: 
/// 1. Create Delegate and Event.
/// 2. Subscribe the event with the method.
/// 3. When condition is met, call the event which is subscribed to the Method. and the Method gets called.
/// Flow: 
/// 1. Object Creation (Main)
/// 2. Event Subscription 
/// 3. Condition check
/// 4. If condition met, Method associated to event is called.
/// </summary>

public class Events
{
    public delegate void Notify(); // Delegate
    public event Notify Reached500;  // Event of delegate type


    public void Calcs()
    {        
        try
        {
            Console.WriteLine("Enter a Number: ");
            int num = int.Parse(Console.ReadLine());

            if (num > 500 )
            { 
                Reached500 += ValueReached500Plus; // Subscribe to the event. Event now knows which method to call when a condition meets.
                Reached500();    // Call event when condition is met. It should be null checked always so, Reached500?.Invoke();
            }   
        }
        catch (FormatException ex) { Console.WriteLine("Invalid Format of Input."); }

    }


    /// <summary>
    /// Delegate Function added to the event.
    /// </summary>
    public static void ValueReached500Plus()
    {
        Console.WriteLine("Event Triggered : Value exceeded 500");
    }

}