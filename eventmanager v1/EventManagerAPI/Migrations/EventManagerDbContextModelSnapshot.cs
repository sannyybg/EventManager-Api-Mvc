﻿// <auto-generated />
using System;
using EventManager.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventManagerAPI.Migrations
{
    [DbContext(typeof(EventManagerDbContext))]
    partial class EventManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventManager.Domain.POCO.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ChangePossibility")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasMaxLength(80)
                        .IsUnicode(false);

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("isAchieved")
                        .HasColumnType("bit");

                    b.Property<bool>("isPublished")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChangePossibility = false,
                            Description = "descr",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2021, 10, 21, 9, 51, 24, 556, DateTimeKind.Local).AddTicks(5652),
                            Title = "titletest",
                            UserId = 1,
                            isAchieved = false,
                            isPublished = false
                        },
                        new
                        {
                            Id = 6,
                            ChangePossibility = false,
                            Description = "descr",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2021, 10, 21, 9, 51, 24, 557, DateTimeKind.Local).AddTicks(8150),
                            Title = "EventTitle",
                            UserId = 2,
                            isAchieved = false,
                            isPublished = false
                        },
                        new
                        {
                            Id = 7,
                            ChangePossibility = false,
                            Description = "description",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2021, 10, 21, 9, 51, 24, 557, DateTimeKind.Local).AddTicks(8228),
                            Title = "FootballMatch",
                            UserId = 3,
                            isAchieved = false,
                            isPublished = false
                        });
                });

            modelBuilder.Entity("EventManager.Domain.POCO.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "test@gmail.com",
                            FirstName = "test",
                            LastName = "test",
                            Password = "test1234",
                            isAdmin = false
                        },
                        new
                        {
                            Id = 2,
                            Email = "james@gmail.com",
                            FirstName = "james",
                            LastName = "smith",
                            Password = "test1234",
                            isAdmin = false
                        },
                        new
                        {
                            Id = 3,
                            Email = "lmessi@gmail.com",
                            FirstName = "leo",
                            LastName = "messi",
                            Password = "test1234",
                            isAdmin = false
                        });
                });

            modelBuilder.Entity("EventManager.Domain.POCO.Event", b =>
                {
                    b.HasOne("EventManager.Domain.POCO.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}