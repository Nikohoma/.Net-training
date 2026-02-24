var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP Pipeline: Sequence of steps that are executed whenever the program is executed.

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())    // If any error in development environment, redirect to error page
//{
//    app.UseExceptionHandler("/Home/Error");
//}

app.UseExceptionHandler("/Home/Error");  // Global Exception Handler : If any error in the whole program, route to the error page

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}") // Conventional Routing : Default routing. Opens this path by default
    .WithStaticAssets();


app.Run();
