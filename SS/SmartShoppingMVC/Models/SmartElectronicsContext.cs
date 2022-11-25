using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartShoppingMVC.Models;

namespace SmartElectronicsMVC.Models
{
    public partial class SmartElectronicsContext : DbContext
    {
        public SmartElectronicsContext()
        {
        }

        public SmartElectronicsContext(DbContextOptions<SmartElectronicsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AudioDescription> AudioDescriptions { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Tvdescription> Tvdescriptions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=SmartElectronics;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudioDescription>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AudioDescription");

                entity.Property(e => e.Brand)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConnectorType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ProdId).HasColumnName("ProdID");

                entity.Property(e => e.SpecialFeature)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__AudioDesc__ProdI__2C3393D0");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__Product__042785C51A8F2D3C");

                entity.ToTable("Product");

                entity.Property(e => e.ProdId).HasColumnName("ProdID");

                entity.Property(e => e.Brand)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Img1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("img1");

                entity.Property(e => e.Img2)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("img2");

                entity.Property(e => e.Img3)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("img3");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__Categor__267ABA7A");
            });

            modelBuilder.Entity<Tvdescription>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TVDescription");

                entity.Property(e => e.Brand)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayTechnology)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Hardware)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ProdId).HasColumnName("ProdID");

                entity.Property(e => e.ScreenSize)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Services)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialFeature)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__TVDescrip__ProdI__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
