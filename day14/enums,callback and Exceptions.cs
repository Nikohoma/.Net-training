namespace day14;

#region Enums
/// <summary>
/// Enum : Data type that stores unknow values as a set of known values
/// </summary>

public enum Weekdays
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}

public enum ProductCategory
{
    Electronics = 1,
    Grocery = 2

}

public enum Semesters
{
    FirstSemester= 1,
    SecondSemester= 2

}

public enum Subjects
{
    Maths = 1,
    Python = 2,
    DBMS = 3,
    OS = 4,
    Networks = 5
}
#endregion

public static class EnumExample
{
    public static string GetDay(Weekdays day, ref int enumValue)
    {
        enumValue = (int)day;
        return day.ToString();
    }

    public static string MenuByDay(Weekdays day)
    {
        switch (day)
        {
            case Weekdays.Monday:
                return "Pasta";
            case Weekdays.Tuesday:
                return "Tacos";
            case Weekdays.Wednesday:
                return "Holiday";
            default:
                return "Chef's Special";
        }
    }

}

#region Callback Delegate
/// <summary>
/// 1. Delegate : Type that represents references to methods with a particular parameter list and return type.
/// </summary>
/// <param name="message"></param>
public delegate void Notify(string message);
public class OrderService
{
    // 2. Delegate as a Parameter Variable
    public void PlaceOrder(int orderId, Notify callback) 
    {
        Console.WriteLine($"Order {orderId} placed.");

        //3. Invoke the callback (Delegate Parameter storing the function)
        callback?.Invoke($"Order {orderId} Confirmation Sent.");
    }

    // 4. Delegate Methods
    public static void SendSMS(string message)
    {
        Console.WriteLine($"SMS: {message}");
    }

    public static void SendEmail(string message)
    {
        Console.WriteLine($"Email: {message}");
    }
}


#endregion

#region Custom Exception

/// <summary>
/// Custom Exception Class
/// </summary>
public class CustomException : Exception
{
    public override string Message => "Internal Exception Occured.";
}


/// <summary>
/// Better Custom Exception Class with Base Message Handling.
/// </summary>
public class BetterCustomException : Exception
{
    public override string Message => HandleBase(base.Message);  // Writing Base Error Message to a File/Log. and Returning Custom Message.

    private string HandleBase(string msg)
    {
        // Original Message from the base Class
        Console.WriteLine(msg);  // can write into a log file.

        return "Internal Exception Occured. Contact Admin";

    }
}


/// <summary>
/// Class to handle exception. Multiple catches can be there in one try-catch. The parent and default exception should be at last, else it would execute. Only one catch get executes.
/// </summary>
public class ExceptionHandling
{
    public void Calc()
    {
        try
        {
            int div = Divide(10, 0);
        }
        catch(BetterCustomException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public int Divide(int a, int b)
    {
        try
        {
            return a / b;
        }
        catch 
        {
            throw new BetterCustomException();
        }
    }

}
#endregion