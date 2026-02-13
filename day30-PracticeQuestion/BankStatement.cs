using System;
using System.Collections.Generic;

class BankStatement
{
    public Dictionary<string, int> CalculateSpend(List<(string category, int amount)> txns)
    {
        var spend = new Dictionary<string, int>();

        foreach (var (category, amount) in txns)
        {
            if (amount >= 0) continue;  

            int positiveAmount = -amount;

            if (spend.ContainsKey(category))
                spend[category] += positiveAmount;
            else
                spend[category] = positiveAmount;
        }
        return spend;
    }
    static void Main()
    {
        Console.Write("Enter transactions: ");
        int n = int.Parse(Console.ReadLine());
        BankStatement bs = new BankStatement();
        var transactions = new List<(string category, int amount)>();
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter category and amount: ");
            string[] input = Console.ReadLine().Split();
            string category = input[0];
            int amount = int.Parse(input[1]);
            transactions.Add((category, amount));
        }

        Dictionary<string, int> result = bs.CalculateSpend(transactions);

        Console.WriteLine("Spend Category:");
        foreach (var k in result)
            Console.WriteLine($"{k.Key} : {k.Value}");
    }

    
}
