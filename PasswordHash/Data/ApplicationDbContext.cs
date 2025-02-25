// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using SecureAuthApp.Models;

namespace SecureAuthApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure the username is unique
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
