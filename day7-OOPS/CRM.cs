using System;
namespace CRM;


public abstract class Customer
{
    #region declarations
    public int Id{get; } public string City{get; set; } public string Phone{get; set;}

    #endregion

    #region Constructor
    public Customer(int Id, string City, string Phone){this.Id = Id; this.City = City; this.Phone = Phone;}

    #endregion

    #region Abstract Function
    public abstract void Info();
    #endregion

}

public class Suspect : Customer
{
    #region Constructor 
    public Suspect(int Id, string City, string Phone) : base(Id,City,Phone){}

    #endregion

    #region Override Function
    public override void Info()
    {
        Console.WriteLine($"Suspect Info : \n Suspect Id: {Id}, Suspect City: {City}, Suspect Contact: {Phone}");
    }

    #endregion
}

public class Prospect : Customer
{
    #region declarations
    public string Offers{get; set;} public int DiscountProvided{get; set;}

    #endregion

    #region Constructor
    public Prospect(int Id, string City, string Phone, string Offers, int DiscountProvided) : base(Id,City,Phone)
    {
        this.Offers = Offers;
        this.DiscountProvided = DiscountProvided;
    }
    #endregion

    #region Override Function
    public override void Info()
    {
        Console.WriteLine($"Prospect Info: \n ID: {Id}, City: {City}, Contact: {Phone} \n Offers: {Offers}, Discount Provided(%): {DiscountProvided}");
    }

    #endregion
}

public class Account : Customer
{
    #region declarations
    public string Feedback {get; init;} public bool SupportProvided {get; set;}
    #endregion

    #region Constructor
    public Account(int Id, string City, string Phone, string Feedback, bool SupportProvided):base(Id,City,Phone)
    {
        this.Feedback = Feedback; this.SupportProvided = SupportProvided;
    }
    #endregion

    #region Override Function
    public override void Info()
    {
        Console.WriteLine($"Account Info: \n ID: {Id}, City: {City}, Phone: {Phone} \n Eligible for Support? : {SupportProvided} \n Customer Feedback: {Feedback}");
    }
    #endregion
}