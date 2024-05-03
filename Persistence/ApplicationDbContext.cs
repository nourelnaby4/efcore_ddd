using Domain.Customers;
using Domain.Orders;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<Order> Orders { get; set; }

        //public DbSet<Product> Products { get; set; }

        //public DbSet<LineItem> LineItems { get; set; }

        //public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }

}
