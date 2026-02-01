using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BikeRentalSystem
{
    public class Bike
    {
        public string Model { get; set;  }
        public string Brand { get; set;  }
        public int PricePerDay { get; set; }

        public Bike(string model, string brand, int pricePerDay)
        {
            Model = model;
            Brand = brand;
            PricePerDay = pricePerDay;
        }
    }
    public class BikeUtility
    {
        public void AddBikeDetails(string model, string brand, int pricePerDay)
        {
            int num = Program.bikeDetails.Count + 1;
            Bike bike = new Bike(model, brand, pricePerDay);
            Program.bikeDetails.Add(num, bike);
        }

        public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
        {
            return new SortedDictionary<string, List<Bike>>(Program.bikeDetails.Values.GroupBy(b => b.Brand).ToDictionary(g => g.Key, g => g.ToList()));
                        
        }


    }

    public class Program
    {
        public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();

        public static void Main(string[] args)
        {
            BikeUtility bikeUtility = new BikeUtility();
            bool exit = false;

            Console.WriteLine("=================Bike Rental System================================");
            while (!exit)
            {
                Console.WriteLine("\n1. Add Bike Details\r\n2. Group Bikes By Brand\r\n3. Exit");

                Console.WriteLine("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nEnter the Brand: ");
                        string brand = Console.ReadLine();
                        Console.WriteLine("\nEnter the Mpdel: ");
                        string model = Console.ReadLine();
                        Console.WriteLine("\nEnter the price per day: ");
                        int pricePerDay = int.Parse(Console.ReadLine());
                        bikeUtility.AddBikeDetails(model, brand, pricePerDay);
                        Console.WriteLine("Bike Details added successfully");

                        break;
                    case 2:
                        foreach (var b in bikeUtility.GroupBikesByBrand())
                        {
                            Console.WriteLine("Brand :"+b.Key);
                            foreach(Bike v in b.Value)
                            {
                                Console.WriteLine($"Model : {v.Model} , PricePerDay: {v.PricePerDay}");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        exit = true;
                        break;

                }
            }
    }

    }
}
