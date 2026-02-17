using System.Text.RegularExpressions;

namespace SmartBankingSystem
{
    public abstract class BankAccount
    {
        public long AccountNumber { get;  }
        public string CustomerName { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(long accountNumber, string customerName, decimal balance)
        {
            AccountNumber = accountNumber;
            CustomerName = customerName;
            Balance = balance;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount > 0) { Balance += amount; Console.WriteLine($"Updated Balance : {Balance}"); }
            else { throw new InvalidTransactionException("Amount invalid."); }
        }
        public virtual void Withdraw(decimal amount)
        {
            if (amount <= Balance) { Balance -= amount; Console.WriteLine($"Updated Balance : {Balance}"); }
            else { throw new InsufficientBalanceException("An Error Occured."); }
        }

        public abstract int CalculateInterest();
    }

    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(long accountNumber, string customerName, decimal balance) : base(accountNumber, customerName, balance)
        {
            
        }

        public override int CalculateInterest()
        {
            return 5;
        }

        public override void Withdraw(decimal amount)
        {
            var amountToDeduct = Balance - amount;
            if (amountToDeduct >= 1000)
            {
                Balance -= amount;
                Console.WriteLine($"Updated Balance : {Balance}");
            }
            else
            {
                throw new MinimumBalanceException("Account should have minimum balance of 1000");
            }
        }
    }

    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(long accountNumber, string customerName, decimal balance) : base(accountNumber, customerName, balance)
        {

        }

        public override int CalculateInterest()
        {
            return 7;
        }

        public override void Withdraw(decimal amount)
        {
            decimal overdraftLimit = 5000m;
            if (Balance - amount >= -overdraftLimit)
            {
                Balance -= amount;
                Console.WriteLine($"Updated Balance : {Balance}");
            }
            else { throw new MinimumBalanceException("Overdraft Limit Reached."); }
        }
    }
    public class LoanAccount : BankAccount
    {
        public LoanAccount(long accountNumber, string customerName, decimal balance) : base(accountNumber, customerName, balance)
        {

        }

        public override int CalculateInterest()
        {
            return 4;
        }
        public override void Deposit(decimal amount)
        {
            throw new InvalidTransactionException("Loan account cannot Deposit.");
        }
    }

    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string msg):base(msg)
        {

        }
    }
    public class MinimumBalanceException : Exception
    {
        public MinimumBalanceException(string msg) : base(msg)
        {

        }
    }
    public class InvalidTransactionException : Exception
    {
        public InvalidTransactionException(string msg) : base(msg)
        {

        }
    }

    public class Management
    {
        private List<BankAccount> _accounts = new List<BankAccount>();
        private List<string> _transactions = new List<string>();
        public List<BankAccount> GetHighBalanceAccounts()
        {
            return new List<BankAccount> (_accounts.Where(balance => balance.Balance > 50000m).ToList());
        }

        public decimal GetTotalBankBalance()
        {
            decimal totalBalance = _accounts.Sum(balance => balance.Balance);
            return totalBalance;
        }

        public List<BankAccount> HighestBalanceAccounts()
        {
            return new List<BankAccount>(_accounts.OrderByDescending(balance => balance.Balance).Take(3).ToList());
        }

        public Dictionary<string,List<BankAccount>> GroupByAccountType()
        {
            return _accounts.GroupBy(r => r.GetType().Name).ToDictionary(g=>g.Key,g=>g.ToList());
        }

        public List<BankAccount> CustomerNameWithR()
        {
            return new List<BankAccount>(_accounts.Where(c => c.CustomerName.StartsWith("R")).ToList());
        }

        public void TransferMoney(long sender, long receiver, decimal amount)
        {
            bool flag = _accounts.Any(a => a.AccountNumber == sender) && _accounts.Any(a => a.AccountNumber == receiver);
            if (flag)
            {
                var senderAccount = _accounts.Where(a => a.AccountNumber == sender).First();
                var receiverAccount = _accounts.Where(a => a.AccountNumber == receiver).First();
                senderAccount.Withdraw(amount);
                receiverAccount.Deposit(amount);
                _transactions.Add($"{amount} sent from {sender} to {receiver} at {DateTime.Now}");
            }
            else
            {
                throw new InvalidTransactionException("Check Account Numbers again.");
            }
        }


    }


}