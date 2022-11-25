﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RailwayManagementLibrary;

#nullable disable

namespace RailwayManagementLibrary.Migrations
{
    [DbContext(typeof(RailwayManagementContext))]
    partial class RailwayManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RailwayManagementLibrary.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("PassengerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("RailwayManagementLibrary.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"), 1L, 1);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("PassengerId");

                    b.HasIndex("TrainId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("RailwayManagementLibrary.Train", b =>
                {
                    b.Property<int>("TrainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainId"), 1L, 1);

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.Property<string>("TrainName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainId");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("RailwayManagementLibrary.TrainScheduleReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("RailwayManagementLibrary.Ticket", b =>
                {
                    b.HasOne("RailwayManagementLibrary.Passenger", "passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayManagementLibrary.Train", "train")
                        .WithMany()
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("passenger");

                    b.Navigation("train");
                });

            modelBuilder.Entity("RailwayManagementLibrary.TrainScheduleReport", b =>
                {
                    b.HasOne("RailwayManagementLibrary.Train", "train")
                        .WithMany()
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("train");
                });
#pragma warning restore 612, 618
        }
    }
}
