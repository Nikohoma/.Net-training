namespace PaymentLib {

public abstract class Payment
{
    #region declaration
    public double Amount;
    #endregion

    #region Constructor
    public Payment(double Amount)
    {
        this.Amount = Amount;
    }
    #endregion

    #region Abstract Function
    public abstract void Pay();
    #endregion

    #region Implemented Function

    public void PrintReceipt()
        {
            Console.WriteLine($"Receipt: Amount {Amount}");
        }

    #endregion

}
}

