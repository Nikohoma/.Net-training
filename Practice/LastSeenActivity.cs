//Track last login time for users and print users inactive for more than 30 days.

using System;
using System.Collections.Generic;

class LastSeenActivity
{
    static void Main()
    {
        Dictionary<string, DateTime> lastLogin = new Dictionary<string, DateTime>
        {
            { "arun", DateTime.Today.AddDays(-10) },
            { "meena", DateTime.Today.AddDays(-45) },
            { "salim", DateTime.Today.AddDays(-60) }
        };

        List<string> result = new List<string>();
        // TODO: Filter and print inactive users
        foreach(var l in lastLogin)
        {
            var lastActive = DateTime.Now - l.Value;
            if (lastActive.Days > 30)
            {
                result.Add(l.Key);
            }
        }

        foreach(var r in result)
        {
            Console.WriteLine(r);
        }
    }
}