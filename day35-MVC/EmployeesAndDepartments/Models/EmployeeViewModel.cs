using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeesAndDepartments.Models
{
   public class EmployeeViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }

        public int DepartmentId { get; set; }
        public List<SelectListItem> Departments { get; set; }
    }
}
