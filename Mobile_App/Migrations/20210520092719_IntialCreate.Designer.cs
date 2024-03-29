﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mobile_App.Models;

namespace Mobile_App.Migrations
{
    [DbContext(typeof(MobileShopDbContext))]
    [Migration("20210520092719_IntialCreate")]
    partial class IntialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mobile_App.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<decimal>("PTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("OrderID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Mobile_App.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Mobile_App.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductModelID")
                        .HasColumnType("int");

                    b.Property<int>("Quantily")
                        .HasColumnType("int");

                    b.Property<int>("Rom")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("ProductID");

                    b.HasIndex("ProductModelID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Mobile_App.Models.ProductModel", b =>
                {
                    b.Property<int>("ProductModelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Battery")
                        .HasColumnType("int");

                    b.Property<string>("Camera")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Chip")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Demensions")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Describe")
                        .HasColumnType("text");

                    b.Property<string>("Display")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Ram")
                        .HasColumnType("int");

                    b.HasKey("ProductModelID");

                    b.ToTable("ProductModels");
                });

            modelBuilder.Entity("Mobile_App.Models.User", b =>
                {
                    b.Property<int>("Usersid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("hoTen")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("maLoaiNguoiDung")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("matKhau")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("soDt")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("taiKhoan")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Usersid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Mobile_App.Models.Order", b =>
                {
                    b.HasOne("Mobile_App.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Mobile_App.Models.OrderDetail", b =>
                {
                    b.HasOne("Mobile_App.Models.Order", null)
                        .WithMany("OderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mobile_App.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Mobile_App.Models.Product", b =>
                {
                    b.HasOne("Mobile_App.Models.ProductModel", "ProductModel")
                        .WithMany()
                        .HasForeignKey("ProductModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductModel");
                });

            modelBuilder.Entity("Mobile_App.Models.Order", b =>
                {
                    b.Navigation("OderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
