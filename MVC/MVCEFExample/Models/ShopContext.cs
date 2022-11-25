using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MVCEFExample.Models;

namespace MVCEFExample.Models
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Userdata> Userdata { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Shop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Product__DD37D91A22131264");

                entity.ToTable("Product");

                entity.Property(e => e.Pid)
                    .ValueGeneratedNever()
                    .HasColumnName("pid");

                entity.Property(e => e.Pname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pname");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.Suppid).HasColumnName("suppid");

                entity.HasOne(d => d.Supp)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Suppid)
                    .HasConstraintName("FK__Product__suppid__267ABA7A");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Sid)
                    .HasName("PK__Supplier__DDDFDD368FC958B0");

                entity.ToTable("Supplier");

                entity.Property(e => e.Sid)
                    .ValueGeneratedNever()
                    .HasColumnName("sid");

                entity.Property(e => e.Sname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sname");
            });

            modelBuilder.Entity<Userdata>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__Userdata__DD701264CD59491C");

                entity.Property(e => e.Uid)
                    .ValueGeneratedNever()
                    .HasColumnName("uid");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Uname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("uname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<MVCEFExample.Models.Employee>? Employee { get; set; }
    }
}
