﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Migrations
{
    [DbContext(typeof(OrderContext))]
    partial class OrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderManagementAPI.Models.Order", b =>
                {
                    b.Property<int>("Order_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order_DeliveryType_Id")
                        .HasColumnType("int");

                    b.Property<int>("Order_Shipping_Address")
                        .HasColumnType("int");

                    b.Property<decimal>("Order_Shipping_Charges")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Order_Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Order_Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Order_Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Order_Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Order_Id");

                    b.ToTable("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}