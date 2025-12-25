namespace MultipleInheritence;

/// <summary>
/// To perform multiple inheritence, just create a interface
/// </summary>


public interface IVeg
{
    public void EatVeg();

    public void getTaste();
}

public interface INonVeg
{
    public void EatNonVeg();

    public void getTaste();
}

public class Guest : IVeg, INonVeg
{
    public void EatVeg(){Console.WriteLine("Guest Can eat veg");}

    public void EatNonVeg() { Console.WriteLine("Guest can eat Non Veg");}

    public void getTaste() {Console.WriteLine("Taste of Veg or Non-Veg?");}

    void IVeg.getTaste()
    {
        Console.WriteLine("Veg taste.");
    }

    void INonVeg.getTaste()
    {
        Console.WriteLine("Non-Veg Taste");
    }

}