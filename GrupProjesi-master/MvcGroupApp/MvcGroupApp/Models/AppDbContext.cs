using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MvcGroupApp.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }


        public AppDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Migrations.Configuration>("DefaultConnection"));

        }
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}