﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NCLBackend.Models;
using System;

namespace NCLBackend.Migrations
{
    [DbContext(typeof(NCLBackendContext))]
    [Migration("20170915204808_First Migration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NCLBackend.Models.Daily", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DATE");

                    b.Property<string>("SALES_REP");

                    b.Property<int>("SalesAmt");

                    b.HasKey("Id");

                    b.ToTable("Daily");
                });

            modelBuilder.Entity("NCLBackend.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IMAGE");

                    b.Property<string>("ITEM");

                    b.Property<string>("ITEM_DESC");

                    b.Property<int>("ON_HAND_QTY");

                    b.Property<int>("PRICE");

                    b.Property<string>("STATUS");

                    b.HasKey("Id");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("NCLBackend.Models.Monthly", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SALES_REP");

                    b.Property<int>("SalesAmt");

                    b.HasKey("Id");

                    b.ToTable("Monthly");
                });

            modelBuilder.Entity("NCLBackend.Models.Quarterly", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SALES_REP");

                    b.Property<int>("SalesAmt");

                    b.HasKey("Id");

                    b.ToTable("Quarterly");
                });

            modelBuilder.Entity("NCLBackend.Models.Quotas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MONTHLY_QUOTA");

                    b.Property<string>("REPNAME");

                    b.Property<string>("SALES_REP");

                    b.Property<int>("YEARLY_QUOTA");

                    b.HasKey("Id");

                    b.ToTable("Quota");
                });

            modelBuilder.Entity("NCLBackend.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FIRSTNAME");

                    b.Property<string>("LASTNAME");

                    b.Property<string>("LOGIN");

                    b.Property<string>("PASSWORD");

                    b.Property<string>("POSITION");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NCLBackend.Models.Weekly", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SALES_REP");

                    b.Property<int>("SalesAmt");

                    b.HasKey("Id");

                    b.ToTable("Weekly");
                });

            modelBuilder.Entity("NCLBackend.Models.Yearly", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SALES_REP");

                    b.Property<int>("SalesAmt");

                    b.HasKey("Id");

                    b.ToTable("Yearly");
                });
#pragma warning restore 612, 618
        }
    }
}