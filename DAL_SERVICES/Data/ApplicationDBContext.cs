using DAL_SERVICES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_SERVICES.Data
{
    public class ApplicationDBContext
    {
        public class ApplicationDbContext : DbContext
        {

            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
                builder.Entity<Customer>()
                .HasIndex(u => u.AccountNumber)
               .IsUnique();
                // builder.Entity<Category>()
                //.Property(u => u.CategoryId)
                //.HasComputedColumnSql("'CATE-' + [Id]");
            }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Merchant> Merchants { get; set; }

            public DbSet<Customer> Customers { get; set; }

            public DbSet<Product> Products { get; set; }

            public DbSet<Order> Orders { get; set; }

            public DbSet<OrderDetail> OrderDetails { get; set; }
        }
    }
}
