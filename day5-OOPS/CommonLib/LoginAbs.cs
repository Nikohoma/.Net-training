namespace CommonLib;

public abstract class LoginAbs
{
    #region Abstract Methods
    public abstract void Login (); //Abstract methods have no body.

    public abstract void Logout();
    
    #endregion


    #region Implemented Function
    public void LoginProcess() //Cannot be overriden
    {
        Console.WriteLine("Need Username and Password ot login.");
    }
    #endregion
}