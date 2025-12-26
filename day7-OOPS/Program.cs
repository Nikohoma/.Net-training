using System;
namespace MultipleInheritence1;


/// <summary>
/// Interface for Singing and Flying
/// </summary>
public interface Ibird1Char
{
    public void Sing();

    public void Fly();


}

/// <summary>
/// Interface for Walking and Flying
/// </summary>
public interface Ibird2Char
{
    public void Walk();

    public void Fly();
}


/// <summary>
/// Bird Class inheriting the interfaces
/// </summary>
public class Bird : Ibird1Char, Ibird2Char
{

    #region Interface Methods
    public void Sing () {Console.WriteLine("This Bird can Sing ");}

    public void Walk() {Console.WriteLine("This Bird can walk");}

    void Ibird1Char.Fly()
    {
        Console.WriteLine("This bird can Sing and Fly");
    }

    void Ibird2Char.Fly() {Console.WriteLine("This bird can walk and fly");}

    #endregion

}

// Reference Parameters

public class Refer
{
    public string Method(int n)
    {
        return $"Method with int {n}";
    }

    public int Method1(ref int a, ref int b)
    {
        int n = a + b;
        a = 100; b =200;
        return n;

    }

    #region Overflow and Round robin
    public int Add(int a, int b)
    {   
        
            checked
            {
                int c = a + b;
                return c;
            }
    }
    #endregion  


    #region Out 
    public void add1 (int n, out int square, out int half)
    {
        square = n * n;
        half = n / 2;

        Console.WriteLine($"Num : {n} , Square: {square}, Half: {half}"); 

    }

    #endregion
}
