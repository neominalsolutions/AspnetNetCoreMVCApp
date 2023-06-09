﻿// <auto-generated />
using AspnetNetCoreMVCApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspnetNetCoreMVCApp.Migrations
{
    [DbContext(typeof(CustomerContext))]
    [Migration("20230530114132_CustomerInit")]
    partial class CustomerInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AspnetNetCoreMVCApp.Data.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("AspnetNetCoreMVCApp.Data.AccountTransaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountTransaction");
                });

            modelBuilder.Entity("AspnetNetCoreMVCApp.Data.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AspnetNetCoreMVCApp.Data.Account", b =>
                {
                    b.HasOne("AspnetNetCoreMVCApp.Data.Customer", null)
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("AspnetNetCoreMVCApp.Data.AccountTransaction", b =>
                {
                    b.HasOne("AspnetNetCoreMVCApp.Data.Account", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AspnetNetCoreMVCApp.Data.Account", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("AspnetNetCoreMVCApp.Data.Customer", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
