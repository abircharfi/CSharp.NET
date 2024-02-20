﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeddingPlanner.Models;

#nullable disable

namespace WeddingPlanner.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240217223859_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AttendanceUser", b =>
                {
                    b.Property<int>("AttendancesAttendanceId")
                        .HasColumnType("int");

                    b.Property<int>("UsersUserId")
                        .HasColumnType("int");

                    b.HasKey("AttendancesAttendanceId", "UsersUserId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("AttendanceUser");
                });

            modelBuilder.Entity("AttendanceWedding", b =>
                {
                    b.Property<int>("GuestsAttendanceId")
                        .HasColumnType("int");

                    b.Property<int>("WeddingsWeddingId")
                        .HasColumnType("int");

                    b.HasKey("GuestsAttendanceId", "WeddingsWeddingId");

                    b.HasIndex("WeddingsWeddingId");

                    b.ToTable("AttendanceWedding");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Attendance", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WeddingId")
                        .HasColumnType("int");

                    b.HasKey("AttendanceId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("WeddingPlanner.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.Property<int>("WeddingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("WeddAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("WeddDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("WedderOne")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WedderTwo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("WeddingId");

                    b.HasIndex("UserId");

                    b.ToTable("Weddings");
                });

            modelBuilder.Entity("AttendanceUser", b =>
                {
                    b.HasOne("WeddingPlanner.Models.Attendance", null)
                        .WithMany()
                        .HasForeignKey("AttendancesAttendanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeddingPlanner.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AttendanceWedding", b =>
                {
                    b.HasOne("WeddingPlanner.Models.Attendance", null)
                        .WithMany()
                        .HasForeignKey("GuestsAttendanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeddingPlanner.Models.Wedding", null)
                        .WithMany()
                        .HasForeignKey("WeddingsWeddingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.HasOne("WeddingPlanner.Models.User", "Creator")
                        .WithMany("WeddingsCreated")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("WeddingPlanner.Models.User", b =>
                {
                    b.Navigation("WeddingsCreated");
                });
#pragma warning restore 612, 618
        }
    }
}