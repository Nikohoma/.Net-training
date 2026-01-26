using System;
using System.Collections.Generic;
using System.Text;

namespace Question8
{
    /// <summary>
    /// Class with a method to transact from the balance
    /// </summary>
    public class Banktransactionprogram
    {
        /// <summary>
        /// Member method to update balance based on the transactions
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="transactions"></param>
        /// <returns></returns>
        public int Transactions(int balance, int[] transactions)
        {
            int accountBalance = balance;
            foreach(var t in transactions)
            {
                if (accountBalance > t) { accountBalance += t; }
            }
            return accountBalance;
        }
    }

    /// <summary>
    /// Main Class
    /// </summary>
    public class MainClass
    {
        public static void Main(string[] args)
        {
            // Transactions list (+ve for deposit , -ve for withdraw)
            int[] transactions = [250, 10, -59, -144, 90];

            Banktransactionprogram b = new Banktransactionprogram();  // Instance Create
            Console.WriteLine(b.Transactions(25000, transactions));   // Calling Method
        } 
        
    }
}
