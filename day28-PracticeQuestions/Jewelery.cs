using System;
using System.Collections.Generic;
using System.Text;

namespace JeweleryIMochaMock
{
    public class Jewelery
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        public Jewelery()
        {

        }
    }

    public class JeweleryUtility
    {
        List<Jewelery> jeweleries = new List<Jewelery>();

        public void AddJewelery(string details)
        {
            string[] parts = details.Split(" ");
            Jewelery j = new Jewelery()
            {
                Id = parts[0],
                Type = parts[1],
                Price = int.Parse(parts[2])
            };
            jeweleries.Add(j);
        }

        public void GetJewelery()
        {
            foreach(var j in jeweleries)
            {
                Console.WriteLine($"Details : {j.Id} {j.Type} {j.Price}");
            }
        }

        public void UpdatePrice(int price)
        {
            foreach(var j in jeweleries)
            {
                j.Price = price;
            }
            Console.WriteLine($"Updated Price : {price}");
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            JeweleryUtility jw = new JeweleryUtility();
            Console.WriteLine("Enter Details : ");
            string details = Console.ReadLine();
            jw.AddJewelery(details);
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
                        int price = int.Parse(parts[1]);
                        //int price = int.Parse(Console.ReadLine());
                        jw.UpdatePrice(price);
                        break;
                    case "3":
                        Console.WriteLine("Thank You");
                        flag = false;
                        return;
                }
            }
        }
    }
}
