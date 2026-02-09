//Cab Fare - Polymorphism (Method Overriding)
//A ride app supports multiple cab types with different fare rules.
//Requirements:
//•	Create base class Cab with virtual method CalculateFare(int km).
//•	Mini: fare = km * 12
//•	Sedan: fare = km * 15 + 50
//•	SUV: fare = km * 18 + 100
//Task: Given cab type and km from user input, compute fare using runtime polymorphism.


namespace CabFare
{
    public class Cab
    {
        public virtual decimal CalculateFare(int km)
        {
            return 0;
        }
    }

    public class Mini : Cab
    {
        public override decimal CalculateFare(int km)
        {
            return km * 12;
        }
    }

    public class Sedan : Cab
    {
        public override decimal CalculateFare(int km)
        {
            return km * 15 + 50;
        }
    }
    public class SUV : Cab
    {
        public override decimal CalculateFare(int km)
        {
            return km * 18 + 100;
        }
    }

    public class User
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Cab Type : ");
            string type = Console.ReadLine();
            Console.WriteLine("Enter km : ");
            int km = int.Parse(Console.ReadLine());

            switch (type.ToLower().Trim())
            {
                case "mini":
                    Mini mini = new Mini();
                    Console.WriteLine($"Fare : {mini.CalculateFare(km)}");
                    break;
                case "sedan":
                    Sedan sedan = new Sedan();
                    Console.WriteLine($"Fare : {sedan.CalculateFare(km)}");
                    break;
                case "suv":
                    SUV suv= new SUV();
                    Console.WriteLine($"Fare : {suv.CalculateFare(km)}");
                    break;
                default:
                    Console.WriteLine("Invalid Type");
                    break;
            }

        }
    }
}