//Track region-wise product sales count using nested dictionary.

using System;
using System.Collections.Generic;

class RegionSales
{
    // TODO: Add data for region/product and print a summary report
    Dictionary<string, Dictionary<string, int>> sales = new Dictionary<string, Dictionary<string, int>>();
    public void AddRegion(string region)
    {
        if (!sales.ContainsKey(region))
        {
            sales.Add(region, new Dictionary<string, int>());
            Console.WriteLine("Region added.");
        }
        else
        {
            throw new Exception("Region already present.");
        }
    }

    public void AddProduct(string region, string productId)
    {
        if (sales.ContainsKey(region))
        {
            sales[region][productId] = 0;
            Console.WriteLine("Product Added");
        }
        else
        {
            throw new Exception("Region not added");
        }
    }

    public void AddProductSalesCount(string region, string productId, int count)
    {
        if (sales.ContainsKey(region))
        {
            sales[region][productId] = count;
            Console.WriteLine("Product Sales Count added.");
        }
        else
        {
            throw new Exception("Region not found.");
        }
    }

    public void GetDetails()
    {
        foreach(var s in sales)
        {
            Console.WriteLine($"Region : {s.Key} ");
            foreach(var v in s.Value)
            {
                Console.WriteLine($" --- Product - {v.Key} , Count - {v.Value}");
            }
            Console.WriteLine( );
        }
    }


    static void Main()
    {
        RegionSales rs = new RegionSales();
        rs.AddRegion("Asia");
        rs.AddRegion("Europe");
        rs.AddRegion("LATAM");

        rs.AddProduct("Asia", "TOY-123");
        rs.AddProduct("Europe", "KJF-933");
        rs.AddProduct("LATAM", "IOE-394");
        rs.AddProduct("Asia", "NBM-847");

        rs.AddProductSalesCount("Asia", "TOY-123", 278);
        rs.AddProductSalesCount("Europe", "KJF-933", 6984);
        rs.AddProductSalesCount("LATAM", "IOE-394", 2823);

        rs.GetDetails();
    }
}