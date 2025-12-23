namespace ScienceLib;
using CommonLib;

public class AeroScience
{
    public double CalculateLift(double area, double liftCoefficient, double velocity, double airDensity)
    {
        return 0.5 * velocity * velocity * area * airDensity;
    }


}

public class ScienceLibSecurityCheck : LoginAbs
{    

    #region constructor
    public ScienceLibSecurityCheck(){}



    #endregion
    public override void Login()
    {
        Console.WriteLine("Science Class Login Successfully");
    }

    public override void Logout()
    {
        Console.WriteLine("Science Class Logout Succesfully");
    }

    
}