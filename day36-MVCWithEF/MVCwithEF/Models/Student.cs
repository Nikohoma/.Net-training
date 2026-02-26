namespace MVCwithEF.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Mark1 { get; set; }
        public double Mark2 { get; set; }

        public Student(int Id, string Name, double Mark1, double Mark2)
        {
            this.Id = Id;
            this.Name = Name;
            this.Mark1 = Mark1;
            this.Mark2 = Mark2;
        }
    }
}
