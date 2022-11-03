﻿// <auto-generated />
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Application.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Student");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 12,
                            Name = "Student 1"
                        },
                        new
                        {
                            Id = 2,
                            Age = 13,
                            Name = "Student 2"
                        },
                        new
                        {
                            Id = 3,
                            Age = 14,
                            Name = "Student 3"
                        },
                        new
                        {
                            Id = 4,
                            Age = 21,
                            Name = "Student 4"
                        },
                        new
                        {
                            Id = 5,
                            Age = 12,
                            Name = "Student 5"
                        },
                        new
                        {
                            Id = 6,
                            Age = 23,
                            Name = "Student 6"
                        },
                        new
                        {
                            Id = 7,
                            Age = 25,
                            Name = "Student 7"
                        },
                        new
                        {
                            Id = 8,
                            Age = 29,
                            Name = "Student 8"
                        },
                        new
                        {
                            Id = 9,
                            Age = 17,
                            Name = "Student 9"
                        },
                        new
                        {
                            Id = 10,
                            Age = 18,
                            Name = "Student 10"
                        },
                        new
                        {
                            Id = 11,
                            Age = 23,
                            Name = "Student 11"
                        },
                        new
                        {
                            Id = 12,
                            Age = 24,
                            Name = "Student 12"
                        },
                        new
                        {
                            Id = 13,
                            Age = 19,
                            Name = "Student 13"
                        },
                        new
                        {
                            Id = 14,
                            Age = 20,
                            Name = "Student 14"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
