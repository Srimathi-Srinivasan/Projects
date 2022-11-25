using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCEFEg.Models
{
    public partial class eurofinsContext : DbContext
    {
        public eurofinsContext()
        {
        }

        public eurofinsContext(DbContextOptions<eurofinsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Dept> Depts { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Fee> Fees { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=eurofins;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__course__D837D05F296ABCA7");

                entity.ToTable("course");

                entity.Property(e => e.Cid)
                    .ValueGeneratedNever()
                    .HasColumnName("cid");

                entity.Property(e => e.Cname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cname");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Did)
                    .HasName("pkdid");

                entity.ToTable("department");

                entity.Property(e => e.Did).HasColumnName("did");
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dept");

                entity.Property(e => e.Did).HasColumnName("did");

                entity.Property(e => e.Dname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dname");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Eid)
                    .HasName("pkeid");

                entity.ToTable("employee");

                entity.Property(e => e.Eid)
                    .ValueGeneratedNever()
                    .HasColumnName("eid");

                entity.Property(e => e.Dept)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dept");

                entity.Property(e => e.Deptid).HasColumnName("deptid");

                entity.Property(e => e.Ename)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ename");

                entity.Property(e => e.Gender)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Joiningdate)
                    .HasColumnType("date")
                    .HasColumnName("joiningdate");

                entity.Property(e => e.Location)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("salary");
            });

            modelBuilder.Entity<Fee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("fees");

                entity.Property(e => e.Amountpaid).HasColumnName("amountpaid");

                entity.Property(e => e.Dept)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dept");

                entity.Property(e => e.Regno).HasColumnName("regno");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Regno)
                    .HasName("pkregno");

                entity.ToTable("student");

                entity.Property(e => e.Regno)
                    .ValueGeneratedNever()
                    .HasColumnName("regno");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Courseid)
                    .HasColumnName("courseid")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.Sname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sname");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Courseid)
                    .HasConstraintName("FK__student__coursei__2A4B4B5E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
