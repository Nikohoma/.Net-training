using Microsoft.AspNetCore.Mvc;
using PartialPostbackExample.Models;

public class TodoController : Controller
{
    // In-memory list (acts like database)
    private static List<Todo> _todos = new List<Todo>();
    private static int _id = 1;

    // Show all tasks
    public IActionResult Index()
    {
        return View(_todos);
    }

    // Add new task
    [HttpPost]
    public IActionResult Create(string title)
    {
        if (!string.IsNullOrEmpty(title))
        {
            _todos.Add(new Todo
            {
                Id = _id++,
                Title = title,
                IsCompleted = false
            });
        }

        return RedirectToAction("Index");
    }

    // Toggle complete
    public IActionResult Toggle(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo != null)
        {
            todo.IsCompleted = !todo.IsCompleted;
        }

        return RedirectToAction("Index");
    }

    // Delete
    public IActionResult Delete(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo != null)
        {
            _todos.Remove(todo);
        }

        return RedirectToAction("Index");
    }
}