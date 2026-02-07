using System.Text.RegularExpressions;

namespace BankChatbot
{
    /// <summary>
    /// Interface that is to be implemented by the BankOperations class
    /// </summary>
    public interface IBankAccountOperation
    {
        public decimal balance { get; set; } 
    }

    /// <summary>
    /// BankOperations class implementing IBankAccountOperation interface with balance set to 0 initially.
    /// Contains Methods for withdraw, deposit and ProcessOperation
    /// </summary>
    public class BankOperations : IBankAccountOperation
    {
        public decimal balance { get; set; } = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        public BankOperations()
        {
        }

        /// <summary>
        /// Method to deposit valid amount
        /// </summary>
        /// <param name="d"></param>
        public void Deposit(decimal d)
        {
            if (d > 0)
            {
                balance += d;
                Console.WriteLine(balance);
            }
            else
            {
                Console.WriteLine("Amount invalid.");
            }
        }

        /// <summary>
        /// Method to withdraw valid amount
        /// </summary>
        /// <param name="d"></param>
        public void Withdraw(decimal d)
        {
            if (d <= balance)
            {
                balance -= d;
                Console.WriteLine(balance);
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        /// <summary>
        /// Method that takes list of string as input and assign methods to each list object accordingly.
        /// </summary>
        /// <param name="s1"></param>
        public void ProcessOperation(List<string> s1)
        {
            foreach (var s in s1)
            {
                if (s.Contains("see") | s.Contains("show"))
                {
                    Console.WriteLine(balance);
                }
                else if (s.Contains("withdraw") | s.Contains("pull"))
                {
                    string inputNum = Regex.Replace(s, @"\D", "");           // replace all alphabets 
                    dynamic m = int.Parse(inputNum);                         // Convert to integer for the digit
                    Withdraw(m);
                }
                else
                {
                    string inputNum = Regex.Replace(s, @"\D", "");            // replace all alphabets 
                    dynamic m = int.Parse(inputNum);                          // Convert to integer for the digit
                    Deposit(m);
                }
            }
            
        }

    }

    /// <summary>
    /// Main Class
    /// </summary>
    public class MainClass
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Instance
            BankOperations bo = new BankOperations();
            // Inputs
            Console.WriteLine("Enter no. of inputs : ");
            int n = int.Parse(Console.ReadLine());

            // List to store all inputs
            List<string> input = new List<string>();
            for(int i=0; i < n; i++)
            {
                string s = Console.ReadLine();
                input.Add(s);
            }
            // Pass list of inputs to the method
            bo.ProcessOperation(input);

        }
    }
}