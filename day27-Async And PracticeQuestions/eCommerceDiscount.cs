//E - Commerce Discount - Abstract Class
//An e-commerce app applies different discount policies.
//Requirements:
//•	Create abstract class DiscountPolicy with abstract method GetFinalAmount(double amount).
//•	FestivalDiscount: 10 % off if amount >= 5000 else 5 %.
//•	MemberDiscount: flat 300 off if amount >= 2000 else no discount.
//Task: Choose policy based on user input and print the final payable amount.

namespace eCommerceDiscount
{
    public abstract class DiscountPolicy
    {
        public abstract double GetFinalAmount(double amount);
    }

    public class FestivalDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            if (amount > 5000) { return amount * 0.9; }
            else { return amount * 0.95; }
        }
    }

    public class MemberDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            if (amount >= 2000) { return amount - 300; }
            else { return amount; }
        }
    }

    public class User
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Are you a member? (Yes/No):");
            string isMember = Console.ReadLine();
            Console.WriteLine("Enter the Amount : ");
            double amount = int.Parse(Console.ReadLine());
            bool ifMember;

            if(isMember.ToLower().Trim() == "yes") { ifMember = true; }
            else { ifMember = false; }

            bool ifFestivalDiscount = true;

            var payableAmount = amount;
            if (ifMember)
            {
                MemberDiscount md = new MemberDiscount();
                payableAmount = md.GetFinalAmount(amount);
                if (ifFestivalDiscount)
                {
                    FestivalDiscount fd = new FestivalDiscount();
                    payableAmount = fd.GetFinalAmount(payableAmount);
                }
                Console.WriteLine($"Amount Payable : {payableAmount}");
            }
            else
            {
                if (ifFestivalDiscount)
                {
                    FestivalDiscount fd = new FestivalDiscount();
                    payableAmount = fd.GetFinalAmount(amount);
                }
                Console.WriteLine($"Amount Payable : {payableAmount}");
            }
        }
    }
}