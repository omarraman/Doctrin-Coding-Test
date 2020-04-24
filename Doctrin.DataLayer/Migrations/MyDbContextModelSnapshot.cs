﻿// <auto-generated />
using System;
using Doctrin.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Doctrin.DataLayer.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Doctrin.DataLayer.EfClasses.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDateTime");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<int>("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("Doctrin.DataLayer.EfClasses.ExceptionDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CalendarId");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("ExceptionDays");
                });

            modelBuilder.Entity("Doctrin.DataLayer.EfClasses.ExceptionSetting", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExceptionDayId");

                    b.Property<string>("SettingId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ExceptionDayId");

                    b.HasIndex("SettingId");

                    b.ToTable("ExceptionSettings");
                });

            modelBuilder.Entity("Doctrin.DataLayer.EfClasses.Setting", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Inheritable");

                    b.Property<int>("UnitId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Doctrin.DataLayer.EfClasses.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Root"
                        });
                });

            modelBuilder.Entity("Doctrin.DataLayer.EfClasses.Calendar", b =>
                {
                    b.HasOne("Doctrin.DataLayer.EfClasses.Unit", "Unit")
                        .WithMany("Calendars")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Doctrin.DataLayer.EfClasses.ExceptionDay", b =>
                {
                    b.HasOne("Doctrin.DataLayer.EfClasses.Calendar", "Calendar")
                        .WithMany("ExceptionDays")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Doctrin.DataLayer.EfClasses.ExceptionSetting", b =>
                {
                    b.HasOne("Doctrin.DataLayer.EfClasses.ExceptionDay", "ExceptionDay")
                        .WithMany("Settings")
                        .HasForeignKey("ExceptionDayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Doctrin.DataLayer.EfClasses.Setting", "Setting")
                        .WithMany()
                        .HasForeignKey("SettingId");
                });

            modelBuilder.Entity("Doctrin.DataLayer.EfClasses.Setting", b =>
                {
                    b.HasOne("Doctrin.DataLayer.EfClasses.Unit", "Unit")
                        .WithMany("Settings")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Doctrin.DataLayer.EfClasses.Unit", b =>
                {
                    b.HasOne("Doctrin.DataLayer.EfClasses.Unit", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
