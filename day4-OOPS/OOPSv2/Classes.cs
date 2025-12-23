using System;
namespace ConstructorPrograms;
public class Visitor
{

    #region declarations
    public int id; public string name; public string requirements;
    #endregion 


    #region Specific parameters constructor
    public Visitor(int id, string name)
    {
        this.id = id;
        if (name.ToLower().Contains("idiot")) throw new ArgumentException("Kya likh rha hai?");
        this.name = name;
    }
    #endregion


    #region Private Constructor
    private Visitor(){}

    #endregion


    #region Parameterised Constructor
    public Visitor(int id, string name, string requirements)
    {
        this.id = id;
        this.name = name;
        this.requirements = requirements;
    }
    #endregion


}

public class Calc
{
    #region declaration
    int num1 {get; set;}
    int num2 {get; set;}
    int sum {get;}  //we dont want to set the value at runtime. Though value can be set in the constructor
    #endregion

    #region Constructor
    public Calc(int num1, int num2)
    {
        this.num1 = num1; 
        this.num2 = num2;
        this.sum = num1 + num2; //get only values can be set only in constructor
        Console.WriteLine($"Sum: {sum}");
    }
    #endregion

    
}


// Logs Mechanism
public class VisitorV2
{
    #region declaration
    public int id {get; set;}

    public string name {get; set;}

    public string requirements {get; set;}
    public string LogHistory {get;}

    #endregion

    #region Constructor Inheritence using this()
    public VisitorV2()
    {
        LogHistory += $"Object 1 created at {DateTime.Now.ToString()} \n";
        // Console.WriteLine(LogHistory);
    }

    public VisitorV2(int id) : this() //to call the previous constructor or take reference
    {
        this.id = id;
        LogHistory += $"Object 2 created at {DateTime.Now.ToString()} \n";
    }

    public VisitorV2(int id, string name) : this(id) //Will get id from previous constructor so no need to mention
    {
        // this.id = id;
        this.name = name;

        LogHistory += $"Object 3 created at {DateTime.Now.ToString()} \n";
        Console.WriteLine(LogHistory);
    }

    public VisitorV2(int id, string name, string requirements) : this(id,name)
    {
        this.requirements = requirements;

        LogHistory += $"Object 4 created at {DateTime.Now.ToString()} \n";
        Console.WriteLine(LogHistory);
    }
    #endregion

}


//Field Example
public class Employee
{   
    #region Fields and property declaration
    private int id; //Field

    //Act as a validator. Using getters and setters we can validate the value.
    public int ID
    {
        set
        {
            if (value < 0) {id = value;} //Assign valid value to id
            else {id = 0;}
        }
    }

    #endregion

    #region Member Method to access private variable
    public void DisplayDetails()
    {
        Console.WriteLine($"id : {id}");
    }
    #endregion
}


#region Tracking all errors and return them at once.
public class Associates
{
    #region fields and validations
    private int id; private string name; private int rank; string Errors = "";
    public int ID 
    {get ; 
        set
        {
            if (value > 0)
            {
                id = value;
            }
            else {Errors += "Error: id cannot be negative. \n";}
        }
    }

    public string Name
    {
        get ;
        set
        {
            if(value != String.Empty)
            {
                name = value;
            }
            else
            {
                Errors += "Error: Name cannot be empty. \n";
            }
        }
    }

    public int Rank
    {
        get;
        set
        {
            if (value > 0)
            {
                rank = value;
            }
            else
            {
                Errors += "Error: Rank cannot be negative";
            }
        }
    }
    #endregion

    #region Member Function
    public void DisplayInfo()
    {
        if (Errors != null) {Console.WriteLine(Errors);}
        else {Console.WriteLine($"Id: {id} , name : {name}, rank : {rank}");}
    }
    #endregion
}

#endregion


//Parent Class
public class Account
{
    #region declarations
    public int id;
    #endregion


    #region Member Function
    public string GetAccountDetails()
    {
        return $"I am base class and my account id is {id}. \n";
    }
    #endregion
}

//Child Class
public class SalesAccount : Account
{
    #region declarations 
    public int Salesid;
    #endregion

    #region Member Function calling parent function using base
    public string GetSalesAccountDetails()
    {
        string info ="";
        info += base.GetAccountDetails();
        info += $"I am Sales derived class and my sales id is {Salesid}";

        return info;
    }

    #endregion

}

public class Father
{
    #region Virtual function
    public virtual string Interest() //virtual: allows this method to be overriden or can be used in child class to return something different.
    {
        return "Father Likes Football";
    }

    #endregion
    
}

public class Son:Father
{
    #region override function
    public override string Interest()  //Overrides the Parent class function. Same function as parent class.
    {
        return "Son Likes Cricket";
    }
    #endregion

}