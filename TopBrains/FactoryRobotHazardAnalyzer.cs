using System;
namespace Ques1;


/// <summary>
/// Class having method to calculate hazard risk
/// </summary>
public class RobotHazardAuditor
{
    #region Method to calculate Hazard risk
    public string CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {

        // Validating Arm Precision input
        if (armPrecision < 0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error: Arm Precision must be 0 - 1.0");
        }

        // Validating Worker Density input
        if (workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Unsupported machinery state");
        }

        // Declaring ms variable that would take a valid Machinery sTate value.
        double ms;

        // Validating Machinery State Input
        if (machineryState.ToLower() == "worn")
        {
            ms = 1.3;
        }
        else if (machineryState.ToLower() == "faulty")
        {
            ms = 2.0;
        }
        else if (machineryState.ToLower() == String.Empty) { throw new RobotSafetyException("Error: Machinery State cannot be null."); }

        else { ms = 3.0; }


        // Calculating HAzard Risk using Formula 
        double HazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * ms);

        //Return the hazard risk score
        return $"Robot Hazard Risk Score: {HazardRisk}";
    }
    #endregion
}


/// <summary>
/// Custom Derived Class to inherit all the exceptions
/// </summary>
public class RobotSafetyException : Exception
{
    public RobotSafetyException(string error) : base(error)
    {
        Console.WriteLine(error);
    }


}

/// <summary>
/// Main Class
/// </summary>
public class MainClass
{
    public static void Main(string[] args)
    {
        RobotHazardAuditor calc = new RobotHazardAuditor();
        Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
        double Armprecision = Double.Parse(Console.ReadLine());
        Console.WriteLine("Enter Worker Density (1-20):");
        int WorkerDensity = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Machinery State:");
        string MachineryState = Console.ReadLine();

        string res = calc.CalculateHazardRisk(Armprecision, WorkerDensity, MachineryState);
        Console.WriteLine(res);

    }
}