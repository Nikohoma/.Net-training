namespace PaymentLib {

public abstract class Payment
{
    #region declaration
    public double Amount;
    #endregion

    #region Constructor
    protected Payment(double Amount)   // protected can be accessed within class or by derived class.
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

