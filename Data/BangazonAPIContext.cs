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
        
        public DbSet<Order> Orders { get; set; }
        public object Order { get; internal set; }

// this is where you set the database relationship to the tables via field sets

        public DbSet<Product> Products { get; set; } //jk-setting up a relationship between the database and the products table

         public DbSet<Employee> Employees { get; set; } //kc- creating the relationship to the db and controller for employee
        public DbSet<Computer> Computers { get; set; } //jk-Here I am setting up a relationship between the Computer table and the database

        public DbSet<TrainingProgram> TrainingPrograms { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; } 


        public DbSet<Customer> Customer { get; set; }
        
        public DbSet<PaymentType> PaymentType { get; set; }

        public DbSet<DeptType> DeptType { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // If a model has a date field that should be generated by the database
            modelBuilder.Entity<Customer>()
                .Property(b => b.DateAccountCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

            modelBuilder.Entity<Product>()  //jk-Created this model builder so a time is automatically generated when a product is added to the database
                .Property(b => b.DateProductAdded)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

        }
    }
}