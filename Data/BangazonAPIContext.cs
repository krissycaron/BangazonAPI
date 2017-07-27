using Microsoft.EntityFrameworkCore; 
using BangazonAPI.Models;

namespace BangazonAPI.Data
{
    public class BangazonAPIContext : DbContext
    {
        public BangazonAPIContext(DbContextOptions<BangazonAPIContext> options)
            : base(options)
        { }

//this is where you set the database relationship to the tables
        public DbSet<Customer> Customers { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // If a model has a date field that should be generated by the database
            modelBuilder.Entity<Customer>()
                .Property(b => b.DateAccountCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

        }
    }
}