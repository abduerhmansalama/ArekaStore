using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Areas.Identity.Data;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class FurnitureDBContext : IdentityDbContext<UsingIdentityUser>
    {
        public FurnitureDBContext(DbContextOptions<FurnitureDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact_Us> Contact_Uss { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Statues> order_Statues { get; set; }
        public DbSet<OrderProduct> orderProducts { get; set; }

        public DbSet<Partener> Parteners { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }      
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<User_Product> User_Products { get; set; }
        public DbSet<ShoppingProduct> ShoppingProducts { get; set; }

    }
}
