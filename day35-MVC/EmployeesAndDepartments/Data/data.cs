using System.Collections.Generic;
using EmployeesAndDepartments.Models;

namespace EmployeesAndDepartments.Data
{
    public static class StaticData
    {
        public static List<Department> Departments = new List<Department>
    {
        new Department { Id = 1, Name = "HR" },
        new Department { Id = 2, Name = "IT" },
        new Department { Id = 3, Name = "Finance" }
    };

        public static List<Employee> Employees = new List<Employee>();
    }
}
