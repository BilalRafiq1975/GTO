// Program.cs
using Microsoft.EntityFrameworkCore;
using SecureAuthApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Get the connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? "server=localhost;port=3306;database=users_db;user=root;password=your_password";

// Configure MySQL with the Pomelo provider
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

// Default route: redirect to Account/Login page
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.Run();
