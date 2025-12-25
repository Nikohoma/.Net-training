namespace MathsLib;
using CommonLib;

public class Algebra
{
    #region Member Methods
    public int Add(int a, int b)
    {
        return a+b;
    }

    public int Subtract ( int a, int b)
    {
        return a - b;
    }
    #endregion
}

public class MathsLibSecurityCheck : LoginAbs
{

    #region Constructor
    public MathsLibSecurityCheck(){}

    #endregion


    public override void Login()
    {
        Console.WriteLine("Maths Class Login Successfully");
    }

    public override void Logout()
    {
        Console.WriteLine("Maths Class Logout Succesfully");
    }
}