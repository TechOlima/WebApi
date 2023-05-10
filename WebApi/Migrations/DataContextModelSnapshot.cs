﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Classes;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApi.Classes.Insert", b =>
                {
                    b.Property<int>("InsertID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InsertID"), 1L, 1);

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("StoneTypeID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("InsertID");

                    b.HasIndex("ProductID");

                    b.HasIndex("StoneTypeID");

                    b.ToTable("Insert");
                });

            modelBuilder.Entity("WebApi.Classes.MaterialType", b =>
                {
                    b.Property<int>("MaterialTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialTypeID"), 1L, 1);

                    b.Property<int>("Fineness")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaterialTypeID");

                    b.ToTable("MaterialType");
                });

            modelBuilder.Entity("WebApi.Classes.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"), 1L, 1);

                    b.Property<string>("ClientEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StateID")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalSum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderID");

                    b.HasIndex("StateID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("WebApi.Classes.Photo", b =>
                {
                    b.Property<int>("PhotoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhotoID"), 1L, 1);

                    b.Property<bool?>("Is_Cover")
                        .HasColumnType("bit");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("photoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhotoID");

                    b.HasIndex("ProductID");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("WebApi.Classes.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equipment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<bool?>("Is_Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("MaterialTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("Size")
                        .HasColumnType("int");

                    b.Property<string>("VendorCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.HasIndex("MaterialTypeID");

                    b.HasIndex("ProductTypeID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("WebApi.Classes.ProductType", b =>
                {
                    b.Property<int>("ProductTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductTypeID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductTypeID");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("WebApi.Classes.State", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateID"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateID");

                    b.ToTable("State");
                });

            modelBuilder.Entity("WebApi.Classes.StoneType", b =>
                {
                    b.Property<int>("StoneTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoneTypeID"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoneTypeID");

                    b.ToTable("StoneType");
                });

            modelBuilder.Entity("WebApi.Classes.Storage", b =>
                {
                    b.Property<int>("StorageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StorageID"), 1L, 1);

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<decimal?>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SupplyID")
                        .HasColumnType("int");

                    b.HasKey("StorageID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.HasIndex("SupplyID");

                    b.ToTable("Storage");
                });

            modelBuilder.Entity("WebApi.Classes.Supply", b =>
                {
                    b.Property<int>("SupplyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplyID"), 1L, 1);

                    b.Property<bool?>("IsReceived")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReceivingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ShippingDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("TotalSum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SupplyID");

                    b.ToTable("Supply");
                });

            modelBuilder.Entity("WebApi.Classes.Insert", b =>
                {
                    b.HasOne("WebApi.Classes.Product", "Product")
                        .WithMany("Inserts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Classes.StoneType", "StoneType")
                        .WithMany()
                        .HasForeignKey("StoneTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("StoneType");
                });

            modelBuilder.Entity("WebApi.Classes.Order", b =>
                {
                    b.HasOne("WebApi.Classes.State", "State")
                        .WithMany()
                        .HasForeignKey("StateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("WebApi.Classes.Photo", b =>
                {
                    b.HasOne("WebApi.Classes.Product", "Product")
                        .WithMany("Photos")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebApi.Classes.Product", b =>
                {
                    b.HasOne("WebApi.Classes.MaterialType", "MaterialType")
                        .WithMany()
                        .HasForeignKey("MaterialTypeID");

                    b.HasOne("WebApi.Classes.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaterialType");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("WebApi.Classes.Storage", b =>
                {
                    b.HasOne("WebApi.Classes.Order", "Order")
                        .WithMany("Storages")
                        .HasForeignKey("OrderID");

                    b.HasOne("WebApi.Classes.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Classes.Supply", "Supply")
                        .WithMany("Storages")
                        .HasForeignKey("SupplyID");

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("Supply");
                });

            modelBuilder.Entity("WebApi.Classes.Order", b =>
                {
                    b.Navigation("Storages");
                });

            modelBuilder.Entity("WebApi.Classes.Product", b =>
                {
                    b.Navigation("Inserts");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("WebApi.Classes.Supply", b =>
                {
                    b.Navigation("Storages");
                });
#pragma warning restore 612, 618
        }
    }
}
