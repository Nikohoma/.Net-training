//22.Detect Fraud Pattern in Transactions (Window + Rules)
//Fraud rules:
//• 3 + transactions > 50,000 within 2 minutes
//• OR same card used in 2 cities within 10 minutes
//Implement List<FraudAlert> DetectFraud(List<Transaction> txns).

namespace DetectFraudPattern
{
    public class Transaction
    {
        public string Id { get; }
        public decimal Amount { get; set; }
        public DateTime Time { get; set; }
        public string Place { get; set; }
        public string FromAccountNumber { get; set; }
        public string ToAccountNumber { get; set; }
        public Transaction()
        {
            Id = DateTime.Now.ToString("ddMMyyyyhhmmss");
        }


    }

    public class FraudAlert
    {
        public int TransactionId { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Place { get; set; }
        public DateTime Time { get; set; }
        public string FromAccountNumber { get; set; }
        public string ToAccountNumber { get; set; }
        public FraudAlert()
        {

        }
    }

    public class DetectFraud
    {
        List<Transaction> transactions = new List<Transaction>();
        List<FraudAlert> fraudAlerts = new List<FraudAlert>();

        public void AddTransaction(string fromAccount, string toAccount, decimal amount, string place)
        {
            try
            {
                if (amount > 0)
                {
                    Transaction t = new Transaction()
                    {
                        Amount = amount,
                        FromAccountNumber = fromAccount,
                        ToAccountNumber = toAccount,
                        Place = place,
                        Time = DateTime.Now

                    };
                    Console.WriteLine("Transaction added.");
                    transactions.Add(t);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : "+e.Message);
            }
        }

        public List<FraudAlert> DetectFraud(List<Transaction> txns)
        {
            List<Transaction> trans = txns.Where(o => o.Amount > 50000).ToList();

            foreach(var t in trans)
            {

            }
        }



    }
}