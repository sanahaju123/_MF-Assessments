using GroceryDelivery.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryDelivery.DataLayer
{
    public class GroceryDbContext : DbContext
    {
        public GroceryDbContext(DbContextOptions<GroceryDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            //Database.Migrate();
        }
        /// <summary>
        /// Creating DbSet for Table
        /// </summary>
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Menubar> Menubars { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> productOrders { get; set; }
        /// <summary>
        /// While Model or Table creating Applaying Primary key to Table
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasKey(x => x.UserId);
            modelBuilder.Entity<Menubar>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Product>()
                .HasKey(x => x.ProductId);
            modelBuilder.Entity<ProductOrder>()
                .HasKey(x => x.OrderId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
