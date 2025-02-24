using TaskManagerDemo.Application;
using TaskManagerDemo.Core;
using TaskManagerDemo.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerUI; // Add this for UseSwaggerUI

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddScoped<ITaskRepository, InMemoryTaskRepository>();
builder.Services.AddScoped<CreateTask>();
builder.Services.AddScoped<ListTasks>();
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManager API V1");
    c.RoutePrefix = string.Empty; // Swagger UI at root
});

// app.UseHttpsRedirection(); // Commented out to avoid HTTPS warning
app.UseAuthorization();
app.MapControllers();

app.Run();