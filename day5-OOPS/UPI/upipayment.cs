
using PaymentLib;

namespace UPI {

public class UPI : Payment
{
    #region declaration
    public string upiId;
    #endregion 


    #region constructor
    public UPI (string upiId, double Amount) : base(Amount)
    {
        this.upiId = upiId;
    }
    #endregion

    #region Override Function
    public override void Pay()
    {
        Console.WriteLine($"Paid {Amount} with UPI.");
    }
    #endregion
    

}
}