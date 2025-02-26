using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using TaskMangmentSystem.Models;

namespace TaskMangmentSystem.Data;
public class AppDbContext : DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
        public DbSet<User> Users {get; set;}
        public DbSet<TaskMangmentSystem.Models.Task> Tasks { get; set; }
    }
