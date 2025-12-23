namespace ScienceLib;

public class AeroScience
{
    public double CalculateLift(double area, double liftCoefficient, double velocity, double airDensity)
    {
        return 0.5 * velocity * velocity * area * airDensity;
    }
}