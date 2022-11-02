﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication_Test_Work.Models;

#nullable disable

namespace WebApplication_Test_Work.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20221031140022_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication_Test_Work.Models.Deposit", b =>
                {
                    b.Property<Guid>("DepositId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FromAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("SumUSD")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ToAccount")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepositId");

                    b.ToTable("Deposits");
                });
#pragma warning restore 612, 618
        }
    }
}
