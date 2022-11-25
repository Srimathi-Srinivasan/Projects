using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ElectronicsAppLibrary.Models
{
    public partial class ElectronicsShoppingContext : DbContext
    {
        public ElectronicsShoppingContext()
        {
        }

        public ElectronicsShoppingContext(DbContextOptions<ElectronicsShoppingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Seller> Sellers { get; set; } = null!;
        public virtual DbSet<ShoppingOrder> ShoppingOrders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ElectronicsShopping;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("PaymentID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ProdId).HasColumnName("ProdID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Payment__Custome__30F848ED");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__Payment__ProdID__31EC6D26");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__Products__042785C57E46C7A6");

                entity.Property(e => e.ProdId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProdID");

                entity.Property(e => e.ProdName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("Seller");

                entity.Property(e => e.SellerId)
                    .ValueGeneratedNever()
                    .HasColumnName("SellerID");

                entity.Property(e => e.ContactAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProdId).HasColumnName("ProdID");

                entity.Property(e => e.SellerName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.Sellers)
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__Seller__ProdID__267ABA7A");
            });

            modelBuilder.Entity<ShoppingOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Shopping__C3905BAF7255EDE2");

                entity.ToTable("ShoppingOrder");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ProdId).HasColumnName("ProdID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ShoppingOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__ShoppingO__Custo__2D27B809");

                entity.HasOne(d => d.Prod)
                    .WithMany(p => p.ShoppingOrders)
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__ShoppingO__ProdI__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
