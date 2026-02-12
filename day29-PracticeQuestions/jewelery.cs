// Jewelery Imocha Styled

using System;

public class Jewelery
{
    public string Id { get; set; }
    public string Type { get; set; }
    public int Price { get; set; }

    public Jewelery(string id, string type, int price)
    {
        Id = id;
        Type = type;
        Price = price;
    }

}

public class JeweleryUtility
{
    Jewelery jewelery;
    public JeweleryUtility(string details)
    {
        string[] parts = details.Split(" ");
        jewelery = new Jewelery(parts[0], parts[1], int.Parse(parts[2]));
    }
    public void GetJewelery()
    {
        Console.WriteLine($"Details : {jewelery.Id} {jewelery.Type} {jewelery.Price}");

    }

    public void UpdatePrice(int price)
    {
        jewelery.Price = price;
        Console.WriteLine("Updated Price : "+price);
    }

}


public class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Write Details : ");
        string inputDetails = Console.ReadLine();
        JeweleryUtility jw = new JeweleryUtility(inputDetails);
        bool flag = true;

        while (flag)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(" ");
            string choice = parts[0];
            switch (choice)
            {
                case "1":
                    jw.GetJewelery();
                    break;
                case "2":
                    var newPrice = int.Parse(parts[1]);
                    jw.UpdatePrice(newPrice);
                    break;
                case "3":
                    Console.WriteLine("Thank You");
                    flag = false;
                    break;

            }
        }

        
    }
}