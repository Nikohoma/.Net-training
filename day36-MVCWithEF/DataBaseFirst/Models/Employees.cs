using System;
using System.Collections.Generic;

namespace DataBaseFirst.Models;

public partial class Employees
{
    public int EmployeeId { get; set; }

    public string? FullName { get; set; }

    public string? Department { get; set; }

    public decimal? Salary { get; set; }
}
