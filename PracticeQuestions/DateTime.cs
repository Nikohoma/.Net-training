using System;

public class Class98
{
    public static void Main(string[] args)
    {
        var output = TimeSpan.FromMinutes(2);     
        Console.WriteLine(output);  //00:02:00
        Console.WriteLine(output.Minutes);   //2
        Console.WriteLine(output.TotalSeconds);   //120

        var date = DateTime.Now;   // DateTime.UtcNow , IST = UTC +5:30
        date = date.AddMinutes(23);
        date = date.AddDays(2);
        date = date.AddMonths(1);
        date = date.AddYears(20);
        Console.WriteLine(date);    //03 / 26 / 2046 15:11:28
    }
}



