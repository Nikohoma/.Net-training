namespace SmartBank
{
    public class CreditRiskProcessor 
    {        
        public bool validateCustomerDetails(int age, string employmentType, double monthlyIncome,double dues,int creditScore, int defaults)
        {
            if (age < 21 || age > 65)
            {
                throw new InvalidCreditDataException("Invalid Age");
            }

            if(employmentType != "Salaried" || employmentType != "Self-Employed")
            {
                throw new InvalidCreditDataException("Invalid Employment Type");
            }

            if (monthlyIncome < 20000)
            {
                throw new InvalidCreditDataException("Invalid Monthly Income");
            }

            if (dues < 0)
            {
                throw new InvalidCreditDataException("Invalid Credit dues.");
            }
            if(creditScore < 300 || creditScore > 900)
            {
                throw new InvalidCreditDataException("Invalid Credit Score.");
            }
            if(defaults < 0)
            {
                throw new InvalidCreditDataException("Invalid default count");
            }
            return true;
        }

        public double calculateCreditLimit(double monthlyIncome, double dues, int creditScore, int defaults)
        {
            var debtRatio = dues / (monthlyIncome * 12);

            if (creditScore < 600 || defaults >=3 || debtRatio > 0.4)
            {
                var creditLimit = 50000;
                return creditLimit;
            }
            if ((creditScore > 600 && creditScore < 749) || (defaults == 1 || defaults ==2))
            {
                var creditLimit = 150000;
                return creditLimit;
            }
            if( creditScore >= 750 && defaults == 0 && debtRatio < 0.25)
            {
                var creditLimit = 300000;
                return creditLimit;
            }
            throw new InvalidCreditDataException("Check Inouts Again.");
        }
    }

    public class InvalidCreditDataException : Exception
    {
        public InvalidCreditDataException(string message):base(message)
        {
        }
    }

    public class UserInterface
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Name :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Age : ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Employment Type : ");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Monthly Income : ");
            double income = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Dues : ");
            double dues = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Score :");
            int score = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Defaults :");
            int defaults = int.Parse(Console.ReadLine());

            CreditRiskProcessor crp = new CreditRiskProcessor();

            try
            {
                if (crp.validateCustomerDetails(age, type, income, dues, score, defaults))
                {
                    crp.calculateCreditLimit(income, dues, score, defaults);
                }
            }
            catch (InvalidCreditDataException e)
            {
                Console.WriteLine(e.Message);
            }
        }        




    }

}