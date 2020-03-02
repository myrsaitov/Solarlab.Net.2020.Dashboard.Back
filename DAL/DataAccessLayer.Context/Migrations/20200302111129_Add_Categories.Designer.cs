﻿// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Context.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200302111129_Add_Categories")]
    partial class Add_Categories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Entities.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("DataAccess.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Транспорт"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Недвижимость"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Мебель"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Одежда"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Бытовая техника"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Косметика"
                        });
                });

            modelBuilder.Entity("DataAccess.Entities.Category", b =>
                {
                    b.HasOne("DataAccess.Entities.Category", "ParentCategory")
                        .WithMany("Childs")
                        .HasForeignKey("ParentCategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
