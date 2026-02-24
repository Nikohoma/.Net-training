//Convert city-to - route dictionary into route-to-list-of-cities dictionary.

using System;
using System.Collections.Generic;

class InvertDictionary
{
    static void Main()
    {
        Dictionary<string, string> cityRoute = new Dictionary<string, string>
        {
            { "Pune", "R1" },
            { "Mumbai", "R2" },
            { "Nashik", "R1" }
        };

        // TODO: Invert and print route-wise cities
        Dictionary<string, string> result = new Dictionary<string, string>();
        foreach (var v in cityRoute)
        {
            if (!result.ContainsKey(v.Value)){
                result.Add(v.Value,v.Key);
            }
            else
            {
                result[v.Value] += " ";
                result[v.Value] += v.Key;
            }
        }

        foreach(var r in result)
        {
            Console.Write(r.Key +": "+r.Value);
            Console.WriteLine();            
        }
    }
}