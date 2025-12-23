public class CalcTax
{
    public static void Main()
    {
        IndianEmployee indianEmployee = new IndianEmployee(40000,"A");
        USEmployee usEmployee = new USEmployee(45000,"B");
        Console.WriteLine(indianEmployee.CalculateTax());
        Console.WriteLine(usEmployee.CalculateTax());
    }
}