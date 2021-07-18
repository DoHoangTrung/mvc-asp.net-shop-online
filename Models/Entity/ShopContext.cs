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
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionStatu> TransactionStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.passWord)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<AccountType>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<AccountType>()
                .HasMany(e => e.Accounts)
                .WithOptional(e => e.AccountType)
                .HasForeignKey(e => e.typeId);

            modelBuilder.Entity<Product>()
                .Property(e => e.name)
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

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.idProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductType>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Transaction)
                .HasForeignKey(e => e.idTransaction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransactionStatu>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.TransactionStatu)
                .HasForeignKey(e => e.statusId);
        }
    }
}
