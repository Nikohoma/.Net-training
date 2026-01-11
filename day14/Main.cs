namespace MainClass;

using day14;
using Events;


public class MainClass
{
    public static void Main(string[] args)
    {
        #region Enum Declaration and Basic Usage
        Weekdays day = Weekdays.Monday;
        Console.WriteLine(day);  // Monday

        int enumValue = 0;
        Console.WriteLine(EnumExample.GetDay(day,ref enumValue));
        Console.WriteLine(enumValue);

        Console.WriteLine(EnumExample.MenuByDay(Weekdays.Friday));
        #endregion

        #region Semester-Subject Mapping using 2D Array and Enums
        int[,] arr1 = new int[2, 5];

        ///Filling the array
        for(int i = 0; i <2; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                arr1[i,j] = j+1;
            }
        }

        ///Printing the array
        for (int i = 0; i < 2; i++)
        { 
            for(int j = 0; j < 5; j++)
            {
                Console.Write(arr1[i,j] + " ");
            }
            Console.WriteLine();

        }

        for(int i = 0; i < 2; i++)
        {
            int semester = i + 1;
            Semesters s = (Semesters)semester;
            Console.WriteLine(s);

            for(int j =0; j< 5; j++)
            {
                Subjects sub = (Subjects)arr1[i,j];
                Console.WriteLine($"Subject {sub}");
            }

        }
        #endregion

        #region Callback Delegate
        Console.WriteLine("\nCallback Delegates output:");
        OrderService orderService = new OrderService();
        orderService.PlaceOrder(101, OrderService.SendSMS);
        orderService.PlaceOrder(102, OrderService.SendEmail);

        #endregion

        #region Custom Exception Handling
        Console.WriteLine("\nException Handling Outputs: \n");
        ExceptionHandling eh = new ExceptionHandling();
        eh.Calc();
        #endregion

        #region Events
        Console.WriteLine("\nEvents Outputs:\n");
        Events e = new Events();
        e.Reached500 += Events.ValueReached500Plus; // Subscribe to the event. Event now knows which method to call when a condition meets. Static Method.
        e.Calcs();
        #endregion


    }
}