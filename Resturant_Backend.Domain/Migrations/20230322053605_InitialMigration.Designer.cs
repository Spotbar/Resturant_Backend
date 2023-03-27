﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resturant_Backend.Domain.DbContexts;

#nullable disable

namespace Resturant_Backend.Domain.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230322053605_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Resturant_Backend.Domain.Entities.DateCredit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DateCredits");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8646863f-2d44-4b43-828d-edaa27de5de5"),
                            Amount = 100000,
                            IsEnable = false,
                            Year = "1401"
                        },
                        new
                        {
                            Id = new Guid("d9ecf8ae-7ed6-405b-a9ba-30ef1fd745ff"),
                            Amount = 100000,
                            IsEnable = true,
                            Year = "1402"
                        });
                });

            modelBuilder.Entity("Resturant_Backend.Domain.Entities.Factor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("DeliveryCost")
                        .HasColumnType("bigint");

                    b.Property<long>("FactorAmount")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("FactorDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FactorNummber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeliveryByCompany")
                        .HasColumnType("bit");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Factors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3fa388a0-12a4-4446-a1ef-3523d00bba51"),
                            DeliveryCost = 15000L,
                            FactorAmount = 200000L,
                            FactorDate = new DateTimeOffset(new DateTime(2023, 3, 22, 9, 6, 0, 140, DateTimeKind.Unspecified).AddTicks(7691), new TimeSpan(0, 3, 30, 0, 0)),
                            FactorNummber = "-1",
                            IsClosed = false,
                            IsDeliveryByCompany = false,
                            RestaurantId = new Guid("4fd22246-6cea-4822-bcec-dec5f25e4d31")
                        },
                        new
                        {
                            Id = new Guid("d2e9c135-b391-4e1b-9580-eddd84c08a5b"),
                            DeliveryCost = 15000L,
                            FactorAmount = 200000L,
                            FactorDate = new DateTimeOffset(new DateTime(2023, 3, 22, 9, 6, 0, 140, DateTimeKind.Unspecified).AddTicks(7735), new TimeSpan(0, 3, 30, 0, 0)),
                            FactorNummber = "-1",
                            IsClosed = false,
                            IsDeliveryByCompany = false,
                            RestaurantId = new Guid("f7ee871d-a62c-44c9-a1e7-b511d1f454bd")
                        },
                        new
                        {
                            Id = new Guid("9a74ab0b-10f6-4bc0-b80a-e98cbd761b70"),
                            DeliveryCost = 15000L,
                            FactorAmount = 200000L,
                            FactorDate = new DateTimeOffset(new DateTime(2023, 3, 22, 9, 6, 0, 140, DateTimeKind.Unspecified).AddTicks(7738), new TimeSpan(0, 3, 30, 0, 0)),
                            FactorNummber = "-1",
                            IsClosed = false,
                            IsDeliveryByCompany = false,
                            RestaurantId = new Guid("f2c8a076-6a05-4671-b4dd-b4a90c47db31")
                        });
                });

            modelBuilder.Entity("Resturant_Backend.Domain.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0e09fc5e-7b3b-4347-abac-ada8d34c23ab"),
                            Name = "IT"
                        },
                        new
                        {
                            Id = new Guid("6b489010-b02f-4c5a-b22c-ef7d3a49559c"),
                            Name = "لجستیک"
                        });
                });

            modelBuilder.Entity("Resturant_Backend.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Cost")
                        .HasColumnType("bigint");

                    b.Property<Guid>("FactorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAccept")
                        .HasColumnType("bit");

                    b.Property<bool>("IsShared")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FactorId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8790654e-07b2-4575-b1e7-529e637d6047"),
                            Cost = 120000L,
                            FactorId = new Guid("3fa388a0-12a4-4446-a1ef-3523d00bba51"),
                            IsAccept = true,
                            IsShared = false,
                            Name = "کوبیده"
                        },
                        new
                        {
                            Id = new Guid("1a90e91e-7bbf-4001-accc-00663b5ce552"),
                            Cost = 800000L,
                            FactorId = new Guid("3fa388a0-12a4-4446-a1ef-3523d00bba51"),
                            IsAccept = true,
                            IsShared = true,
                            Name = "عدس پلو"
                        });
                });

            modelBuilder.Entity("Resturant_Backend.Domain.Entities.Restaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpratorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fd22246-6cea-4822-bcec-dec5f25e4d31"),
                            Name = "گلی خانم",
                            Tel = "0831"
                        },
                        new
                        {
                            Id = new Guid("f7ee871d-a62c-44c9-a1e7-b511d1f454bd"),
                            Name = "باغ گیلاس",
                            Tel = "0831"
                        },
                        new
                        {
                            Id = new Guid("f2c8a076-6a05-4671-b4dd-b4a90c47db31"),
                            Name = "پارسی",
                            Tel = "0831"
                        });
                });

            modelBuilder.Entity("Resturant_Backend.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("JoinDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Post")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("61e68580-c217-4e24-bb1e-89cfd0b20737"),
                            IsEnable = true,
                            JoinDate = new DateTimeOffset(new DateTime(2023, 3, 22, 9, 6, 0, 140, DateTimeKind.Unspecified).AddTicks(7639), new TimeSpan(0, 3, 30, 0, 0)),
                            Name = "حسن الفت",
                            NationalCode = "3240486611",
                            Password = ""
                        },
                        new
                        {
                            Id = new Guid("b2771cc8-1533-417e-85c5-a762a3065227"),
                            IsEnable = true,
                            JoinDate = new DateTimeOffset(new DateTime(2023, 3, 22, 9, 6, 0, 140, DateTimeKind.Unspecified).AddTicks(7665), new TimeSpan(0, 3, 30, 0, 0)),
                            Name = "الهام شهری",
                            NationalCode = "",
                            Password = ""
                        });
                });

            modelBuilder.Entity("Resturant_Backend.Domain.Entities.UserGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGroups");

                    b.HasData(
                        new
                        {
                            Id = new Guid("04032e9b-6157-4947-b191-b69bd899fa8d"),
                            GroupId = new Guid("0e09fc5e-7b3b-4347-abac-ada8d34c23ab"),
                            UserId = new Guid("61e68580-c217-4e24-bb1e-89cfd0b20737")
                        },
                        new
                        {
                            Id = new Guid("fe4be73e-d6ed-46de-9f30-db8ea6c13c8d"),
                            GroupId = new Guid("0e09fc5e-7b3b-4347-abac-ada8d34c23ab"),
                            UserId = new Guid("b2771cc8-1533-417e-85c5-a762a3065227")
                        });
                });

            modelBuilder.Entity("Resturant_Backend.Domain.Entities.UserOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOrders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("85e2b7be-5425-46a5-a7f2-d3ea63cd93d1"),
                            Amount = 120000L,
                            OrderId = new Guid("8790654e-07b2-4575-b1e7-529e637d6047"),
                            UserId = new Guid("61e68580-c217-4e24-bb1e-89cfd0b20737")
                        },
                        new
                        {
                            Id = new Guid("73059b2e-802c-44dd-affc-7d1ff99de4c2"),
                            Amount = 40000L,
                            OrderId = new Guid("1a90e91e-7bbf-4001-accc-00663b5ce552"),
                            UserId = new Guid("b2771cc8-1533-417e-85c5-a762a3065227")
                        },
                        new
                        {
                            Id = new Guid("5c813bb4-0285-429b-9303-ec5c29b1c90a"),
                            Amount = 40000L,
                            OrderId = new Guid("1a90e91e-7bbf-4001-accc-00663b5ce552"),
                            UserId = new Guid("61e68580-c217-4e24-bb1e-89cfd0b20737")
                        });
                });

            modelBuilder.Entity("Resturant_Backend.Domain.Entities.Factor", b =>
                {
                    b.HasOne("Resturant_Backend.Domain.Entities.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Resturant_Backend.Domain.Entities.Order", b =>
                {
                    b.HasOne("Resturant_Backend.Domain.Entities.Factor", "Factor")
                        .WithMany()
                        .HasForeignKey("FactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factor");
                });

            modelBuilder.Entity("Resturant_Backend.Domain.Entities.UserGroup", b =>
                {
                    b.HasOne("Resturant_Backend.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Resturant_Backend.Domain.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Resturant_Backend.Domain.Entities.UserOrder", b =>
                {
                    b.HasOne("Resturant_Backend.Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Resturant_Backend.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
