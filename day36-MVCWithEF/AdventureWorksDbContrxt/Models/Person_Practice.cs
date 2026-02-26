using System;
using System.Collections.Generic;

namespace AdventureWorksDbContrxt.Models;

public partial class Person_Practice
{
    public int BusinessEntityID { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }
}
