using System.Text.RegularExpressions;

namespace CampusHire
{
    public enum CurrentLocation
    {
        Mumbai, Pune, Chennai
    }

    public enum PreferedLocation
    {
        Mumbai, Pune, Chennai, Kolkata, Delhi, Banagalore
    }

    public enum Core
    {
        DotNet, Java, Oracle, Testing
    }
    public class Applicant
    {
        private string _id;
        public string Id 
        { 
            get { return _id; }
            set {
                if (!Regex.IsMatch(value, @"^CH[0-9]{6}$")) { throw new Exception("Invalid Id"); }
                else { _id = value; }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new Exception("Name cannot be empty."); }
                if (value.Length < 4 || value.Length > 15) { throw new Exception("Name length invalid."); }
                else { _name = value; }
            }
        }

        public CurrentLocation CurrentLocation { get; set; }
        public PreferedLocation PreferedLocation { get; set; }

        public Core CoreCompetency { get; set; }
        public int PassingYear { get; set; }

        public int PassingYearValidator 
        { 
            get { return PassingYear; }
            set
            {
                if(PassingYear < int.Parse(DateTime.Now.ToString("yyyy"))) { throw new Exception("Invalid Year."); }
                PassingYear = value;
            }
        }

        public Applicant()
        {

        }
    }

    public class Operations
    {
        private List<Applicant> _applicants = new List<Applicant>();

        public void AddApplicant(Applicant applicant)
        {
            _applicants.Add(applicant);
            Console.WriteLine("Applicant added.");
        }

        public List<Applicant> GetAllApplicants()
        {
            return _applicants.AsReadOnly().ToList();
        }

        public void SearchApplicant(string Id)
        {
            var result = _applicants.Where(s => s.Id.ToString() == Id);
            foreach(var r in result)
            {
                Console.WriteLine($"{r.Id} | {r.Name} | {r.CurrentLocation} | {r.PreferedLocation} | {r.CoreCompetency} | {r.PassingYear}.");
                return;
            }
            Console.WriteLine("Applicant not found.");

        }

        public void UpdateDetails(string id, int year)
        {
            foreach(var ap in _applicants)
            {
                if (ap.Id.ToString() == id)
                {
                    ap.PassingYear = year;
                    Console.WriteLine("Details Updated.");
                    return;
                }
            }
            Console.WriteLine("No Such Student.");
        }

        public void DeleteApplicant(string id)
        {
            Applicant objectToRemove = default;
            foreach(var ap in _applicants)
            {
                if (ap.Id.ToString() == id)
                {
                    objectToRemove = ap;
                }
            }
            if (objectToRemove != null) 
            {
                _applicants.Remove(objectToRemove);
                Console.WriteLine("Applicant Removed.");
            }
            else
            {
                Console.WriteLine("Could not find the specified Id.");
            }
        }

    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            Operations op = new Operations();
            Applicant a1 = new Applicant()
            {
                Id = "CH123456",
                Name = "Nikhil",
                CurrentLocation = CurrentLocation.Mumbai,
                PreferedLocation = PreferedLocation.Delhi,
                CoreCompetency = Core.DotNet,
                PassingYear = 2026
            };
            Applicant a2 = new Applicant()
            {
                Id = "CH125676",
                Name = "Punya",
                CurrentLocation = CurrentLocation.Pune,
                PreferedLocation = PreferedLocation.Delhi,
                CoreCompetency = Core.Java,
                PassingYear = 2028
            };
            op.AddApplicant(a1);
            op.AddApplicant(a2);
            op.SearchApplicant("CH125676");
            op.UpdateDetails("CH125676", 2027);
            op.DeleteApplicant("CH125676");
            
            foreach(var p in op.GetAllApplicants())
            {
                Console.WriteLine(p.Name + " | " + p.CoreCompetency + " | " + p.PassingYear);
            }
            

        }
    }
}