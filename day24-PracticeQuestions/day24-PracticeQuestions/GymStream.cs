using System;

namespace GymStream
{
    // 1. CUSTOM EXCEPTION CLASS
    public class InvalidTierException : Exception
    {
        public InvalidTierException(string message) : base(message) { }
    }

    // 2. CORE MEMBERSHIP CLASS
    public class Membership
    {
        public string Tier { get; set; }
        public int DurationInMonths { get; set; }
        public double BasePricePerMonth { get; set; }

        /// <summary>
        /// Validates business rules for Tier and Duration.
        /// Throws specific exceptions if rules are violated.
        /// </summary>
        public bool ValidateEnrollment()
        {
            // Tier Validation (Case Sensitive)
            if (Tier != "Basic" && Tier != "Premium" && Tier != "Elite")
            {
                throw new InvalidTierException("Tier not recognized. Please choose an available membership plan.");
            }

            // Duration Validation
            if (DurationInMonths <= 0)
            {
                throw new Exception("Duration must be at least one month.");
            }

            return true;
        }

        /// <summary>
        /// Calculates the final bill after applying Tier-based loyalty discounts.
        /// </summary>
        public double CalculateTotalBill()
        {
            double totalPrice = DurationInMonths * BasePricePerMonth;
            double discountPercentage = 0;

            switch (Tier)
            {
                case "Basic":
                    discountPercentage = 2;
                    break;
                case "Premium":
                    discountPercentage = 7;
                    break;
                case "Elite":
                    discountPercentage = 12;
                    break;
            }

            double discountAmount = totalPrice * (discountPercentage / 100);
            return totalPrice - discountAmount;
        }
    }

    // 3. PROGRAM ENTRY POINT
    public class Program
    {
        static void Main(string[] args)
        {
            Membership member = new Membership();

            try
            {
                Console.WriteLine("--- GymStream Enrollment Portal ---");

                Console.WriteLine("Enter membership tier (Basic/Premium/Elite):");
                member.Tier = Console.ReadLine();

                Console.WriteLine("Enter duration in months:");
                member.DurationInMonths = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter base price per month:");
                member.BasePricePerMonth = Convert.ToDouble(Console.ReadLine());

                // Perform Validation
                if (member.ValidateEnrollment())
                {
                    Console.WriteLine("\nEnrollment Successful!");
                    double finalBill = member.CalculateTotalBill();
                    Console.WriteLine($"Total amount after discount: {finalBill:F2}");
                }
            }
            // Catch Block 1: Custom Exception for Tiers
            catch (InvalidTierException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            // Catch Block 2: General Exception for Duration or numeric errors
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to close...");
            Console.ReadKey();
        }
    }
}
