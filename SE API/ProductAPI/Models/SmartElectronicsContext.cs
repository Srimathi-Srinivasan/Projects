using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProductAPI.Models
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

        public virtual DbSet<Product> Products { get; set; } = null!;

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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
