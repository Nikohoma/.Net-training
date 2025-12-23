public abstract class Employee {

    #region declarations
    public string Name;
    public double Salary;
    #endregion

    #region Constructor
    public Employee(double Salary, string Name)
    {
        this.Salary = Salary;
        this.Name = Name;
    }
    #endregion 

    #region Abstract Member Function
    public abstract string CalculateTax(); //Cannot declare body since it is abstract. It must be implemented in child class
    #endregion

}

public class IndianEmployee : Employee
{   
    #region Constructor
    public IndianEmployee(double Salary, string Name) : base(Salary,Name) {}
    #endregion

    #region Override Member Function
    public override string CalculateTax()
    {
        return $"Tax to pay: {Salary * 0.3}";
    }
    #endregion

}

public class USEmployee : Employee
{
    #region Constructor
    public USEmployee(double Salary, string Name):base(Salary,Name) {}
    #endregion

    #region Override Member Function
    public override string CalculateTax()
    {
        return $"Tax to pay: {Salary *0.4}";
    }
    #endregion

}