using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Hoc_ASP.NET_MVC.Models.Entity
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderStatu> OrderStatus { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.nameLogin)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.passWord)
                .IsUnicode(false);

            modelBuilder.Entity<AccountType>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<AccountType>()
                .HasMany(e => e.Accounts)
                .WithOptional(e => e.AccountType)
                .HasForeignKey(e => e.typeId);

            modelBuilder.Entity<Customer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Payments)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.idCustomer);

            modelBuilder.Entity<OrderStatu>()
                .HasMany(e => e.Payments)
                .WithOptional(e => e.OrderStatu)
                .HasForeignKey(e => e.idOrderStatus);

            modelBuilder.Entity<Product>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.supplier)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.img0)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.img1)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.img2)
                .IsUnicode(false);

            modelBuilder.Entity<ProductType>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
