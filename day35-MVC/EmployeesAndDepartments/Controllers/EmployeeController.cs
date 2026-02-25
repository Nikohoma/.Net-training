using EmployeesAndDepartments.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class EmployeeController : Controller
{
    // Static list to store employees
    private static List<Employee> employees = new List<Employee>();

    // GET: Employee/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Employee/Create
    [HttpPost]
    public IActionResult Create(Employee emp)
    {
        employees.Add(emp);

        return RedirectToAction("Index");
    }

    // GET: Employee/Index
    public IActionResult Index()
    {
        return View(employees);
    }
}