using System.Text.RegularExpressions;

namespace HealthSync
{
    public abstract class Consultant
    {
        private string _Id;
        public string Id {
            get { return _Id; }
            set { 
                if(!Regex.IsMatch(value,@"^DR[0-9]{4}$")) { throw new Exception("Invalid Id"); }
                else { _Id = value; }
            }
        }

        private string _MonthlyStipend;
        public string MonthlyStipend {get;set;}


        public Consultant(string id,string monthlyStipend)
        {
            Id = id;
            MonthlyStipend = monthlyStipend;
        }

        public abstract decimal CalculateGrossPayout(string input);
        public virtual int CalculateTax() { return 0; }
        public virtual decimal CalculateNetPayout(string stipend) { return 0; }
    }

    public class InHouse : Consultant
    {
        public InHouse(string _Id, string _MonthlyStipend) : base(_Id, _MonthlyStipend)
        {

        }

        public override decimal CalculateGrossPayout(string stipend)
        {
            var result = (Decimal.Parse(stipend) * 0.3m) + Decimal.Parse(stipend);
            return result;
        }

        public override int CalculateTax()
        {
            if(Decimal.Parse(MonthlyStipend) <= 5000) { return 10; }
            else { return 15; }
        }

        public override decimal CalculateNetPayout(string stipend)
        {
            var tax = CalculateTax();
            var gross = CalculateGrossPayout(stipend);
            var pay =  gross - gross*(tax / 100m);
            return pay;
        }
        
    }

    public class Visiting : Consultant
    {
        public Visiting(string _Id, string _MonthlyStipend) : base(_Id, _MonthlyStipend)
        {

        }

        public override decimal CalculateGrossPayout(string input)
        {
            string[] parts = input.Split(" ");
            decimal monthlyStipend = Decimal.Parse(parts[0]) * Decimal.Parse(parts[3]);
            return monthlyStipend;
        }

        public override int CalculateTax()
        {
            return 10;
        }

        public override decimal CalculateNetPayout(string stipend)
        {
            var tax = CalculateTax();
            var gross = CalculateGrossPayout(stipend);
            var pay = gross - gross*(tax/100m);
            return pay;
        }
    }

    public class Utility
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("IN HOUSE");
                Consultant c = new InHouse("DR8005", "10000");
                Console.WriteLine($"Gross: {c.CalculateGrossPayout("10000")} | TDS applied : {c.CalculateTax()}% | Payout: {c.CalculateNetPayout("10000")}");
                Console.WriteLine("Visitor");
                Consultant c1 = new Visiting("DR9000", "10 Visits @ 600");
                Console.WriteLine($"Gross: {c1.CalculateGrossPayout("10 Visits @ 600")} | TDS applied : {c1.CalculateTax()}% | Payout: {c1.CalculateNetPayout("10 Visits @ 600")}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }

}