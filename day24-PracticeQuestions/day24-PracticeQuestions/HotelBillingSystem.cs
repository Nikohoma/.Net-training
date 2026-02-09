namespace HotelBillingSystem
{
    public interface IRoom
    {
        public double calculateTotalBill(int nightsStayed, int joiningYear);
        public int calculateMemberShipYears(int joiningYear);
    }

    public class HotelRoomClass : IRoom
    {
        public string RoomType { get; set; }
        public double ratePerNight { get; set; }
        public string guestName { get; set; }

        public HotelRoomClass()
        {

        }

        public int calculateMemberShipYears(int joiningYear)
        {
            int memberShip = int.Parse(DateTime.Now.ToString("yyyy")) - joiningYear;
            return memberShip;
        }

        public double calculateTotalBill(int nightsStayed, int joiningYear)
        {
            int memberShip = calculateMemberShipYears(joiningYear);
            double totalBill = nightsStayed * ratePerNight;
            if(memberShip > 3) { return Math.Round(totalBill * 0.9,0); }
            else { return Math.Round(totalBill,0); }
        }
    }

    public class UserInterface
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Deluxe Room Details :");
            Console.WriteLine("\nGuest Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Rate per Night :");
            double rate = Double.Parse(Console.ReadLine());
            Console.WriteLine("Nights Stayed :");
            int nights = int.Parse(Console.ReadLine());
            Console.WriteLine("Joining Year :");
            int year = int.Parse(Console.ReadLine());

            HotelRoomClass deluxe = new HotelRoomClass()
            {
                RoomType = "Deluxe",
                ratePerNight = rate,
                guestName = name??"Guest"
            };

            Console.WriteLine("\nEnter Suite Room Details :");
            Console.WriteLine("\nGuest Name : ");
            string name1 = Console.ReadLine();
            Console.WriteLine("Rate per Night :");
            double rate1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("Nights Stayed :");
            int nights1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Joining Year :");
            int year1 = int.Parse(Console.ReadLine());

            HotelRoomClass suite = new HotelRoomClass()
            {
                RoomType = "Suite",
                ratePerNight = rate1,
                guestName = name1 ?? "Guest"
            };

            Console.WriteLine("\nRoom Summary: ");
            Console.WriteLine($"Deluxe Room : {deluxe.guestName}, {deluxe.ratePerNight} per night, Membership : {deluxe.calculateMemberShipYears(year)}");
            Console.WriteLine($"Suite Room : {suite.guestName}, {suite.ratePerNight} per night, Membership : {suite.calculateMemberShipYears(year1)}");
            Console.WriteLine();
            Console.WriteLine("Total Bill:");
            Console.WriteLine();
            Console.WriteLine($"For {name} (Deluxe) : {deluxe.calculateTotalBill(nights,year)}" );
            Console.WriteLine($"For {name1} (Suite) : {suite.calculateTotalBill(nights1,year1)}" );

        }
    }



}