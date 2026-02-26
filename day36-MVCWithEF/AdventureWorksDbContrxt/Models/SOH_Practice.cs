using System;
using System.Collections.Generic;

namespace AdventureWorksDbContrxt.Models;

public partial class SOH_Practice
{
    public int SalesOrderID { get; set; }

    public int CustomerID { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal SubTotal { get; set; }

    public decimal TaxAmt { get; set; }

    public decimal Freight { get; set; }

    public decimal TotalDue { get; set; }
}
