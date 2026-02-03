using System;

class BankAccount
{
    static void Main()
    {
        int balance = 10000;

        Console.WriteLine("Enter withdrawal amount:");
        
        // TODO:
        // 1. Throw exception if amount <= 0
        // 2. Throw exception if amount > balance
        // 3. Deduct amount if valid
        // 4. Use finally block to log transaction

        try
        {
            int amount = int.Parse(Console.ReadLine());

            if (amount <= 0)
            {
                throw new Exception("Amount should be more than 0.");
            }
            if (amount > balance)
            {
                throw new Exception("Insufficient Balance.");
            }
            balance -= amount;
            Console.WriteLine($"Withdrawal Successfull. Updated Balance : {balance}");

        }
        catch (Exception ex) { Console.WriteLine("Error Encountered: "+ex.Message); }

        finally
        {
            Console.WriteLine($"Last Transaction attempt at {DateTime.Now}");
        }
    }
}