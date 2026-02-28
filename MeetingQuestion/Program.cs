using System.Linq.Expressions;

namespace Question
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateOnly Dob { get; set; }
        public DateOnly Doj { get; set; }
        public string City { get; set; }

        public Employee(int Id, string FirstName, string LastName, string Title, DateOnly Dob, DateOnly Doj, string City)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Title = Title;
            this.Dob = Dob;
            this.Doj = Doj;
            this.City = City;
        }
    }

    public class MainClass
    {
        private static List<Employee> _employees = new List<Employee>();

        public static List<Employee> DisplayDetails()
        {
            return _employees.AsReadOnly().ToList();
        }

        public static List<Employee> EmployeesNotInMumbai()
        {
            var emp = _employees.Where(l => l.City != "Mumbai").ToList();
            return emp;
        }

        public static List<Employee> EmployeesAsstManager()
        {
            var emp = _employees.Where(t => t.Title == "AsstManager").ToList();
            return emp;
        }

        public static List<Employee> EmployeesLastNameS()
        {
            var emp = _employees.Where(l => l.LastName.StartsWith("S")).ToList();
            return emp;
        }

        public static List<Employee> EmployeesJoiningDate()
        {
            var emp = _employees.Where(d => d.Doj < DateOnly.Parse("1/1/2015")).ToList();
            return emp;
        }

        public static List<Employee> EmployeeBornAfter1990()
        {
            var emp = _employees.Where(d => d.Dob > DateOnly.Parse("1/1/1990")).ToList();
            return emp;
        }

        public static List<Employee> ConsultantOrAssociate()
        {
            var emp = _employees.Where(t => t.Title == "Consultant" || t.Title == "Associate").ToList();
            return emp;
        }

        public static int TotalEmployees()
        {
            var count = _employees.Count();
            return count;
        }

        public static int EmployeesFromChennai()
        {
            var count = _employees.Count(c=>c.City == "Chennai");
            return count;
        }

        public static int HighestEmployeeId()
        {
            var id = _employees.Max(i => i.Id);
            return id;
        }

        public static int EmployeesJoinedAfter2015()
        {
            var count = _employees.Count(d => d.Doj > DateOnly.Parse("1/1/2015"));
            return count;
        }

        public static int NotAssociate()
        {
            var count = _employees.Count(a => a.Title != "Associate");
            return count;
        }

        public static Dictionary<string, int> EmployeesBasedOnCity()
        {
            var emp = _employees.GroupBy(c => c.City).ToDictionary(g => g.Key, g => g.Count());
            return emp;
        }
        public static Dictionary<string, List<string>> EmployeesBasedOnCityAndTitle()
        {
            var emp = _employees.GroupBy(c => c.City).ToDictionary(g => g.Key, g => g.Select(t=>t.Title).Distinct().ToList());
            return emp;
        }

        public static Employee YoungestEmployee()
        {
            var result = _employees.OrderByDescending(d => d.Dob).FirstOrDefault();
            return result;
        }


        public static void Main(string[] args)
        {
            _employees.Add(new Employee(1001, "Malcolm", "Daruwala", "Manager", DateOnly.Parse("16/11/1984"), DateOnly.Parse("8/6/2011"), "Mumbai"));
            _employees.Add(new Employee(1002, "Asdin", "Dhalla", "AsstManager", DateOnly.Parse("20/08/1984"), DateOnly.Parse("7/7/2012"), "Mumbai"));
            _employees.Add(new Employee(1003, "Madhavi", "Oza", "Consultant", DateOnly.Parse("14/11/1987"), DateOnly.Parse("12/4/2015"), "Pune"));
            _employees.Add(new Employee(1004, "Saba", "Shaikh", "SE", DateOnly.Parse("3/6/1990"), DateOnly.Parse("2/2/2016"), "Pune"));
            _employees.Add(new Employee(1005, "Nazia", "Shaikh", "SE", DateOnly.Parse("8/3/1991"), DateOnly.Parse("2/2/2016"), "Mumbai"));
            _employees.Add(new Employee(1006, "Amit", "Pathak", "Consultant", DateOnly.Parse("7/11/1989"), DateOnly.Parse("8/8/2014"), "Chennai"));
            _employees.Add(new Employee(1007, "Vijay", "Natrajan", "Consultant", DateOnly.Parse("2/12/1989"), DateOnly.Parse("1/6/2015"), "Mumbai"));
            _employees.Add(new Employee(1008, "Rahul", "Dubey", "Associate", DateOnly.Parse("11/11/1993"), DateOnly.Parse("6/11/2014"), "Chennai"));
            _employees.Add(new Employee(1009, "Suresh", "Mistry", "Associate", DateOnly.Parse("12/8/1992"), DateOnly.Parse("3/12/2014"), "Chennai"));
            _employees.Add(new Employee(1010, "Sumit", "Shah", "Manager", DateOnly.Parse("12/4/1991"), DateOnly.Parse("2/1/2016"), "Pune"));

            Console.WriteLine("\nDetails Of Employees\n");
            foreach(var d in DisplayDetails())
            {
                Console.WriteLine($"{d.Id} | {d.FirstName} | {d.LastName} | {d.Title} | {d.Dob} | {d.Doj} | {d.City}");
            }

            Console.WriteLine("\nEmployees Not In Mumbai\n");
            foreach(var d in EmployeesNotInMumbai())
            {
                Console.WriteLine($"{d.Id} | {d.FirstName} | {d.LastName} | {d.Title} | {d.Dob} | {d.Doj} | {d.City}");

            }

            Console.WriteLine("\nAssistant Managers\n");
            foreach (var d in EmployeesAsstManager())
            {
                Console.WriteLine($"{d.Id} | {d.FirstName} | {d.LastName} | {d.Title} | {d.Dob} | {d.Doj} | {d.City}");

            }

            Console.WriteLine("\nLast Name starts with S\n");
            foreach (var d in EmployeesLastNameS())
            {
                Console.WriteLine($"{d.Id} | {d.FirstName} | {d.LastName} | {d.Title} | {d.Dob} | {d.Doj} | {d.City}");

            }

            Console.WriteLine("\nJoining Date Before 2015\n");
            foreach (var d in EmployeesJoiningDate())
            {
                Console.WriteLine($"{d.Id} | {d.FirstName} | {d.LastName} | {d.Title} | {d.Dob} | {d.Doj} | {d.City}");

            }
            Console.WriteLine("\nJoining Date After 1990\n");
            foreach (var d in EmployeeBornAfter1990())
            {
                Console.WriteLine($"{d.Id} | {d.FirstName} | {d.LastName} | {d.Title} | {d.Dob} | {d.Doj} | {d.City}");

            }
            Console.WriteLine("\nConsultant And Associate\n");
            foreach (var d in ConsultantOrAssociate())
            {
                Console.WriteLine($"{d.Id} | {d.FirstName} | {d.LastName} | {d.Title} | {d.Dob} | {d.Doj} | {d.City}");

            }
            Console.WriteLine("\nTotal No. Of Employees : " + TotalEmployees());


            Console.WriteLine("\nNo. Of Employees from Chennai : "+ EmployeesFromChennai());

            Console.WriteLine("\nHighest Employee Id : "+ HighestEmployeeId());
            Console.WriteLine("\nNumber of Employees joined after 2015 : "+ EmployeesJoinedAfter2015());
            Console.WriteLine("\nNumber of Employees that are not associates : "+ NotAssociate());

            Console.WriteLine("\nEmployees based on City\n");
            foreach(var e in EmployeesBasedOnCity())
            {
                Console.WriteLine(e.Key +" : "+e.Value);
            }

            Console.WriteLine("\nEmployees based on City And Title\n");
            foreach (var e in EmployeesBasedOnCityAndTitle())
            {
                Console.Write(e.Key + " : "); foreach(var v in e.Value) { Console.Write($" {v} "); }
                Console.WriteLine();
            }

            Console.WriteLine("\nYoungest Employee\n");
            var youngestEmployee = YoungestEmployee();
            Console.WriteLine($"{youngestEmployee.Id} | {youngestEmployee.FirstName} | {youngestEmployee.LastName} | {youngestEmployee.Dob} | {youngestEmployee.Doj} | {youngestEmployee.City}");

        }
    }


}