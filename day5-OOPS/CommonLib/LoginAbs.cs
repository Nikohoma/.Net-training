namespace CommonLib;

public abstract class LoginAbs
{
    #region Abstract Functions
    public abstract void Login ();

    public abstract void Logout();
    
    #endregion


    #region Implemented Function
    public void LoginProcess() //Cannot be overriden
    {
        Console.WriteLine("Need Username and Password ot login.");
    }
    #endregion
}