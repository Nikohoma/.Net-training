using System.Text.RegularExpressions;
using System;
using System.Net;

public class MainClass847
{
    public static void Main()
    {
        string s = "₹1,000.72";
        var result = Regex.IsMatch(s, @"^[$₹](\d{1,3})([,]\d{3})*(\.\d{2})?$");
        Console.WriteLine(result);

        string ip = "192.168.0.1";
        bool isValid = IPAddress.TryParse(ip, out _);
        Console.WriteLine(isValid);


        string mac = "00:1A:2B:3C:4D:5E";
        var validMac = Regex.IsMatch(mac, @"^([0-9A-Fa-f]{2}[:-]){5}[0-9A-Fa-f]{2}$");
        Console.WriteLine("Mac check : " + validMac);

        var validIp = Regex.IsMatch(ip, @"^((25[0-5]|2[0-4]\d|1\d\d|[0-9]?\d)[.]){3}(25[0-5]|2[0-4]\d|1\d\d|[0-9]?\d)$");
        Console.WriteLine("IP check : " + validIp);

        var ipv6 = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
        var validv6 = Regex.IsMatch(ipv6, @"^(([0-9A-Fa-f]{1,4})[:|::]){7}[0-9A-Fa-f]{1,4}$");
        Console.WriteLine(validv6);

    }
}