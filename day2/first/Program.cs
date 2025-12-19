public class Program
{

    /// <summary>
    ///  Method to check if Number is Even
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public bool isEven(int num)
    {
        // return num %2 == 0;

        // if (num % 2 == 0) {Console.WriteLine("Even");}
        // else {Console.WriteLine("Odd");}

        return num%2 == 0;
        
    }
    static void Main()
    {
        #region dd
        // Console.WriteLine("Enter a Number: ");
        // int n = int.Parse(Console.ReadLine());

        Program p1 = new Program();  /// To call non static methods (instance method in this case: normal method in the class), need to call them with object reference

        
        // while (true)       // Infinite Loop to check if Number is Even.
        // {   
        //     Console.WriteLine("Enter the number to check. Press 0 to exit.");            
        //     int number = int.Parse(Console.ReadLine());
        //     if (number == 0) {break;}
        //     Console.WriteLine(p1.isEven(number));
        // }



        // Other improvised Way 

        #endregion

        //region : inputs and Declaration
        Console.WriteLine("Enter the Number or Type Exit");
        string? choice = Console.ReadLine();


        
        while (choice != "Exit" && choice != "exit" && choice != "EXIT")
        {
            // if(int.TryParse(choice, out int n)) {Console.WriteLine(p1.isEven(n));}
            int.TryParse(choice, out int n);
            Console.WriteLine(p1.isEven(n));
            
            Console.WriteLine("Enter your Choice: ");
            choice = Console.ReadLine();
        }

        
    }
}
