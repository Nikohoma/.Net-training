using System;
using ConstructorPrograms; //Importing ConstructorPrograms namespace
namespace ConstructorProgramsMainFunction;


public class Hotel
{

    public static void Main()
    {

        #region Instances

        //Visitor visitor = new Visitor(); //Empty Private Constructor Object (can be accessed inside the same class)
        Visitor visitor1 = new Visitor(1,"A"); //Specific Parameters Constructor object
        Visitor visitor2 = new Visitor(1,"B", "Laptop"); //Parameterised Constructor object

        Calc calc = new Calc(2,3);

        //Constructor inheritence Instances
        VisitorV2 visit1 = new VisitorV2();
        VisitorV2 visit2 = new VisitorV2(7,"R");
        VisitorV2 visit = new VisitorV2(5,"KL","Phone");

        //FieldExample Instances
        Employee e1= new Employee();
        e1.ID = 1;
        // e1.DisplayDetails();
        
        //Associates object
        Associates a1 = new Associates();
        a1.ID = -2; a1.Name = ""; a1.Rank = -2;
        a1.DisplayInfo();


        //Account and Sales account
        Account account = new Account();
        account.id = 1;
        Console.WriteLine(account.GetAccountDetails());

        SalesAccount salesAccount = new SalesAccount() {Salesid = 2};
        Console.WriteLine(salesAccount.GetSalesAccountDetails());


        Son son = new Son();
        Console.WriteLine(son.Interest());

        #endregion

    }


}