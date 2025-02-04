using pickles.Services;

var builder = WebApplication.CreateBuilder(args);

// Register StudentService
builder.Services.AddSingleton<StudentService>();

// Add MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Enable MVC Routing
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
