using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace EmployeesAndDepartments.Middleware
{
    
    public class NameValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public NameValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Only validate POST requests to Employee/Create
            if (context.Request.Method == "POST" && context.Request.Path.Value.Contains("/Employee/Create"))
            {
                var form = await context.Request.ReadFormAsync();
                var name = form["FullName"].ToString();

                if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Name must be at least 3 characters.");
                    return; // Stop pipeline
                }
            }

            await _next(context); // Continue to controller
        }
    }
}
