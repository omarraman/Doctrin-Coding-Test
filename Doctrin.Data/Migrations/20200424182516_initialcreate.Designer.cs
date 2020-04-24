﻿// <auto-generated />
using System;
using Doctrin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Doctrin.Data.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200424182516_initialcreate")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Doctrin.Core.Entities.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDateTime");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<int>("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Calendar");
                });

            modelBuilder.Entity("Doctrin.Core.Entities.ExceptionDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CalendarId");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("ExceptionDay");
                });

            modelBuilder.Entity("Doctrin.Core.Entities.ExceptionSetting", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExceptionDayId");

                    b.Property<string>("SettingId");

                    b.Property<int?>("SettingId1");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ExceptionDayId");

                    b.HasIndex("SettingId1");

                    b.ToTable("ExceptionSetting");
                });

            modelBuilder.Entity("Doctrin.Core.Entities.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GlobalId")
                        .IsRequired();

                    b.Property<bool>("Inheritable");

                    b.Property<int>("UnitId");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UnitId", "GlobalId")
                        .IsUnique();

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GlobalId = "Opening Hours",
                            Inheritable = false,
                            UnitId = 1,
                            Value = "9:00-17:00"
                        });
                });

            modelBuilder.Entity("Doctrin.Core.Entities.Unit", b =>
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

            modelBuilder.Entity("Doctrin.Core.Entities.Calendar", b =>
                {
                    b.HasOne("Doctrin.Core.Entities.Unit", "Unit")
                        .WithMany("Calendars")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Doctrin.Core.Entities.ExceptionDay", b =>
                {
                    b.HasOne("Doctrin.Core.Entities.Calendar", "Calendar")
                        .WithMany("ExceptionDays")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Doctrin.Core.Entities.ExceptionSetting", b =>
                {
                    b.HasOne("Doctrin.Core.Entities.ExceptionDay", "ExceptionDay")
                        .WithMany("Settings")
                        .HasForeignKey("ExceptionDayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Doctrin.Core.Entities.Setting", "Setting")
                        .WithMany()
                        .HasForeignKey("SettingId1");
                });

            modelBuilder.Entity("Doctrin.Core.Entities.Setting", b =>
                {
                    b.HasOne("Doctrin.Core.Entities.Unit", "Unit")
                        .WithMany("Settings")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Doctrin.Core.Entities.Unit", b =>
                {
                    b.HasOne("Doctrin.Core.Entities.Unit", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
