﻿// <auto-generated />
using System;
using EventManager.PersistenceDB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventManagerAPI.Migrations
{
    [DbContext(typeof(EventManagerDbContext))]
    [Migration("20211009100421_initial2")]
    partial class initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("char(80)")
                        .IsFixedLength(true)
                        .HasMaxLength(80)
                        .IsUnicode(false);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("char(20)")
                        .IsFixedLength(true)
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<bool>("isPublished")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "descr",
                            StartDate = new DateTime(2021, 10, 9, 14, 4, 20, 782, DateTimeKind.Local).AddTicks(5840),
                            Title = "titletest",
                            isPublished = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}