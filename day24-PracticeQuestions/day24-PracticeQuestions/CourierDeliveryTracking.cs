namespace CourierDeliveryTracking
{
    public class Package
    {
        private static int _counter = 100;
        public string TrackingNumber { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string DestinationAddress { get; set; }
        public double Weight { get; set; }
        public string PackageType { get; set; }
        public double ShippingCost { get; set; }

        public Package()
        {
            TrackingNumber = _counter++.ToString();
        }
    }

    public class DeliveryStatus
    {
        public string TrackingNumber { get; set; }
        public List<string> CheckPoints { get; set; }

        public string CurrentStatus { get; set; }
        public DateTime EstimatedDelivery { get; set; }
        public DateTime ActualDelivery { get; set; }

        public DeliveryStatus()
        {
            CheckPoints = new List<string>();
        }
    }

    public class CourierManager
    {
        List<Package> packages = new List<Package>();
        List<DeliveryStatus> status = new List<DeliveryStatus>();

        public void AddPackage(string sender, string receiver, string address, double weight, string type, double cost)
        {
            Package p = new Package()
            {
                SenderName = sender,
                ReceiverName = receiver,
                DestinationAddress = address,
                Weight = weight,
                PackageType = type,
                ShippingCost = cost
            };
            packages.Add(p);
            Console.WriteLine("Package Added Successfully.");
        }

        public bool UpdateStatus(string trackingNumber, string status,string checkpoint)
        {
            foreach (Package p in packages)
            {
                if (p.TrackingNumber == trackingNumber)
                {
                    DeliveryStatus d = new DeliveryStatus()
                    {
                        TrackingNumber = p.TrackingNumber,
                        CurrentStatus = status,
                        CheckPoints = { { checkpoint} } 
                    };
                    Console.WriteLine("Status Updated Successfully.");
                    return true;
                }
            }
            Console.WriteLine("Cannot find the package. Check Tracking Number again.");
            return false;
        }

        public Dictionary<string, List<Package>> GroupPackagesByType()
        {
            return packages.GroupBy(p => p.PackageType).ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Package> GetPackagesByDestination(string city)
        {
            return packages.Where(c => c.DestinationAddress.Contains(city)).ToList();
        }

        public List<Package> GetDelayedPackages()
        {
            var trackingNumbers = status.Where(c => c.CurrentStatus != "Delivered" && c.EstimatedDelivery < DateTime.Now).Select(t => t.TrackingNumber).ToList();
            List<Package> result = new List<Package>();
            foreach(var t in trackingNumbers)
            {
                foreach(Package p in packages)
                {
                    if (t == p.TrackingNumber)
                    {
                        result.Add(p);
                    }
                }
            }
            return result;
        }

    }


    public class MainClass
    {
        public static void Main(string[] args)
        {
            CourierManager cm = new CourierManager();
            cm.AddPackage("Nikhil", "Harsh", "Uttam Nagar, New Delhi", 2.3, "Fragile", 350);
            cm.AddPackage("Nikhil", "Vibhu", "Janak Puri, New Delhi", 4.2, "Fragile", 550);
            cm.AddPackage("Abhinav", "Vishal", "Noida, Uttar Prades", 0.4, "Document", 140);

            cm.UpdateStatus("101", "Dispatched", "Reached Delhi");
            cm.UpdateStatus("102", "Delivered", "Reached Destination");
            cm.UpdateStatus("103", "InTransit", "Enroute to Nearest Hub");

            Console.WriteLine("Packages By Type: ");
            foreach(var k in cm.GroupPackagesByType())
            {
                Console.WriteLine($"Package Type : {k.Key}");
                foreach(var v in k.Value)
                {
                    Console.WriteLine($" ---- Packages : {v}");
                }
            }

            Console.WriteLine("Packages By Destination");
            foreach(var s in cm.GetPackagesByDestination("New Delhi"))
            {
                Console.WriteLine($"Package Destination : {s.DestinationAddress} , Tracking Number : {s.TrackingNumber}");
            }

            Console.WriteLine("Delayed Packages");
            foreach(var s in cm.GetDelayedPackages())
            {
                Console.WriteLine($"Tracking Number : {s.TrackingNumber}");
            }
        }
    }


}