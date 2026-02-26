using System;
using System.Collections.Generic;

namespace AdventureWorksDbContrxt.Models;

public partial class SalesOrderDetail_Practice
{
    public int SalesOrderID { get; set; }

    public int SalesOrderDetailID { get; set; }

    public int ProductID { get; set; }

    public short OrderQty { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal LineTotal { get; set; }

    public DateTime ModifiedDate { get; set; }
}
