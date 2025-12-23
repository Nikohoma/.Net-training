namespace CalcMain;
using MathsLib;
using ScienceLib;
using CommonLib;
using PaymentLib;
using UPI;

public class CalcMain
{
    public static void Main()
    {
        #region Objects

        Algebra algebra = new Algebra();
        AeroScience aeroScience = new AeroScience();

        ScienceLibSecurityCheck scienceLibSecurityCheck = new ScienceLibSecurityCheck();
        scienceLibSecurityCheck.Login();
        scienceLibSecurityCheck.Logout();

        MathsLibSecurityCheck mathsLibSecurityCheck = new MathsLibSecurityCheck();
        mathsLibSecurityCheck.Login();
        mathsLibSecurityCheck.Logout();

        UPI upi = new UPI("ASVAS",2000);
        upi.Pay();
        upi.PrintReceipt();


        #endregion
    }
}