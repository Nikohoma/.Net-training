namespace RealEstatePropertyManagement
{
    public class Property
    {
        private static int _counter = 1;
        public string PropertyId { get; set; }
        public string Address { get; set; }
        public string PropertyType { get; set; }
        public int Bedrooms { get; set; }
        public double AreaSqFt { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public string Owner { get; set; }

        public Property()
        {
            PropertyId = _counter++.ToString();
        }
    }

    public class Client
    {
        private static int _counter = 100;
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string ClientType { get; set; }
        public double Budget { get; set; }
        public List<string> Requirements { get; set; }

        public Client()
        {
            ClientId = _counter++;
        }
    }

    public class Viewing
    {
        private static int _counter = 1;
        public int ViewingId { get; set; }
        public string PropertyId { get; set; }
        public int ClientId { get; set; }
        public DateTime ViewingDate { get; set; }
        public string Feedback { get; set; }

        public Viewing()
        {
            ViewingId = _counter++;
        }
    }

    public class RealEstateManagement
    {
        public List<Property> properties = new List<Property>();
        public List<Client> clients = new List<Client>();
        public List<Viewing> viewers = new List<Viewing>();
        public void AddProperty( string address, string type, int bedrooms, double area, double price, string owner)
        {
            Property property = new Property()
            {
                Address = address,
                PropertyType = type,
                Bedrooms = bedrooms,
                AreaSqFt = area,
                Price = price,
                Owner = owner
            };
            properties.Add(property);
        }

        public void AddClient(string name, string contact, string type, double budget, List<string> requirements)
        {
            Client client = new Client()
            {
                Name = name,
                Contact = contact,
                ClientType = type,
                Budget = budget,
                Requirements = requirements
            };
            clients.Add(client);
        }

        public bool ScheduleViewing(string propertyId, int clientId, DateTime date)
        {
            foreach (Client c in clients)
            {
                if (c.ClientId == clientId)
                {
                    foreach (Property p in properties)
                    {
                        if (p.PropertyId == propertyId)
                        {
                            Viewing viewing = new Viewing()
                            {
                                PropertyId = propertyId,
                                ClientId = clientId,
                                ViewingDate = date.Date
                            };
                            Console.WriteLine("Viewing Scheduled.");
                            return true;
                        }
                    }
                    return false;
                }
            }
            return false;
        }

        public Dictionary<string,List<Property>> GroupPropertiesByType()
        {
            return properties.GroupBy(p => p.PropertyType).ToDictionary(p => p.Key, p => p.ToList());
        }

        public List<Property> GetPropertiesInBudget(double minPrice, double maxPrice)
        {
            return properties.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            RealEstateManagement rem = new RealEstateManagement();
            rem.AddProperty("New Delhi", "Villa", 5, 10000, 250000000, "Owner 1");
            rem.AddProperty("Gurgaon", "Apartment", 2, 2500, 8500000, "Owner 2");
            rem.AddProperty("Noida", "House", 3, 5000, 10000000, "Owner 3");

            List<string> req = new List<string>();
            req.Add("3 Bedrooms"); req.Add("Lawn");
            rem.AddClient("Nikhil","984932432","Buyer",12500000,req);

            rem.ScheduleViewing("1", 101, new DateTime(2026, 06, 02, 05, 30, 00));

            foreach(var s in rem.GroupPropertiesByType())
            {
                Console.WriteLine($"Property Type : {s.Key}");
                foreach(var v in s.Value)
                {
                    Console.WriteLine($" -- Bedrooms : {v.Bedrooms}, Area : {v.AreaSqFt}, Price : {v.Price}");
                }
            }

            foreach(var k in rem.GetPropertiesInBudget(10000000, 20000000))
            {
                Console.WriteLine("Properties : ");
                Console.WriteLine(k.PropertyId);
            }
        }
    }


}