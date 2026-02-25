namespace MedicineInventory
{
    public class Medicine
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int ExpiryYear { get; set; }

        public Medicine()
        {

        }
    }

    public class InvalidPriceException : Exception
    {
        public InvalidPriceException(string message) : base(message)
        {

        }
    }
    public class InvalidExpiryYear : Exception
    {
        public InvalidExpiryYear(string message) : base(message)
        {

        }
    }
    public class DuplicateMedicineException : Exception
    {
        public DuplicateMedicineException(string message) : base(message)
        {

        }
    }

    public class MedicineNotFoundException : Exception
    {
        public MedicineNotFoundException(string message) : base(message)
        {

        }
    }

    public class MedicineUtility
    {
        private SortedDictionary<string, Medicine> _meds = new SortedDictionary<string, Medicine>();

        public void AddMedicine(Medicine medicine)
        {
            if (medicine.Price < 0)
            {
                throw new InvalidPriceException("Invalid Price. Price must be more than 0.");
            }
            if (medicine.ExpiryYear < int.Parse(DateTime.Now.ToString("yyyy")))
            {
                throw new InvalidExpiryYear("Expiry Year Invalid.");
            }
            foreach (var m in _meds)
            {
                if (medicine.Id == m.Value.Id)
                {
                    throw new DuplicateMedicineException("Medicine already added.");
                }
            }
            _meds.Add(medicine.Id, medicine);
            Console.WriteLine("Medicine Added Successfully.");
        }

        public Dictionary<string,Medicine> GetAllMedicines()
        {
            if (_meds.Count == 0) { Console.WriteLine("No Medicines in stock."); }
            return _meds.OrderBy(m => m.Value.ExpiryYear).ToDictionary(m=>m.Key,m=>m.Value);
        }

        public void UpdateMedicinePrice(string id, int newPrice)
        {
            foreach (var m in _meds)
            {
                if (m.Key == id)
                {
                    m.Value.Price = newPrice;
                    Console.WriteLine("Price Updated.");
                    return;
                }
            }
            throw new MedicineNotFoundException("Could not found the specified medicine.");
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            MedicineUtility mu = new MedicineUtility();
            bool flag = true;

            Console.WriteLine("=========================");
            Console.WriteLine("===========MENU==========");
            Console.WriteLine("=========================");
            Console.WriteLine("1. Display All Medicines (sorted by expiry year).");
            Console.WriteLine("2. Update Medicine Price. (price id)");
            Console.WriteLine("3. Add Medicine.");
            Console.WriteLine("4. Exit.");

            while (flag)
            {
                try
                {
                    Console.WriteLine("Enter choice : ");
                    string input = Console.ReadLine();
                    string[] parts = input.Split(" ");
                    int choice = int.Parse(parts[0]);
                    switch (choice)
                    {
                        case 1:
                            var result = mu.GetAllMedicines();
                            foreach (var r in result)
                            {
                                Console.WriteLine($"Details : {r.Key} {r.Value.Name} {r.Value.Price} {r.Value.ExpiryYear}");
                            }
                            break;
                        case 2:
                            int newPrice = int.Parse(parts[1]);
                            string id = parts[2];
                            mu.UpdateMedicinePrice(id, newPrice);
                            break;
                        case 3:
                            Console.WriteLine("Enter Id : ");
                            string Id = Console.ReadLine();
                            Console.WriteLine("Enter Name : ");
                            string Name = Console.ReadLine();
                            Console.WriteLine("Enter Price : ");
                            int Price = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Expiry Year : ");
                            int Year = int.Parse(Console.ReadLine());
                            Medicine med = new Medicine()
                            {
                                Id = Id,
                                Name = Name,
                                Price = Price,
                                ExpiryYear = Year
                            };
                            mu.AddMedicine(med);
                            break;
                        case 4:
                            Console.WriteLine("Thank You");
                            flag = false;
                            return;
                    }
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }

        }
    }

}