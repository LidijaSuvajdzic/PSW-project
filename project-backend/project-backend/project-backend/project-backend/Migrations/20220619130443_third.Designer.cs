﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using project_backend.Models;

namespace project_backend.Migrations
{
    [DbContext(typeof(MyWebApiContext))]
    [Migration("20220619130443_third")]
    partial class third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("project_backend.Models.FreeAppointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnName("dateFrom");

                    b.Property<DateTime>("DateTo")
                        .HasColumnName("dateTo");

                    b.Property<int>("DoctorId")
                        .HasColumnName("doctorId");

                    b.Property<bool>("IsFree")
                        .HasColumnName("isFree");

                    b.HasKey("Id");

                    b.ToTable("freeAppointment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateFrom = new DateTime(2022, 6, 20, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2022, 6, 20, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 2,
                            IsFree = true
                        },
                        new
                        {
                            Id = 2,
                            DateFrom = new DateTime(2022, 6, 20, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2022, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 2,
                            IsFree = true
                        },
                        new
                        {
                            Id = 3,
                            DateFrom = new DateTime(2022, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2022, 6, 20, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 3,
                            IsFree = true
                        },
                        new
                        {
                            Id = 4,
                            DateFrom = new DateTime(2022, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2022, 6, 20, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 4,
                            IsFree = true
                        });
                });

            modelBuilder.Entity("project_backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("userid");

                    b.Property<string>("Email")
                        .HasColumnName("email");

                    b.Property<string>("Firstname")
                        .HasColumnName("firstname");

                    b.Property<int>("HealthCardNumber")
                        .HasColumnName("healthcardnumber");

                    b.Property<string>("Lastname")
                        .HasColumnName("lastname");

                    b.Property<string>("Passwordd")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .HasColumnName("role");

                    b.HasKey("UserId");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "suvajdziclidija@gmail.com",
                            Firstname = "Lidija",
                            HealthCardNumber = 1234567890,
                            Lastname = "Suvajdzic",
                            Passwordd = "1234567890",
                            Role = "ADMIN"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "draganaarsin97@gmail.com",
                            Firstname = "Dragana",
                            HealthCardNumber = 987654321,
                            Lastname = "Arsin",
                            Passwordd = "1234567890",
                            Role = "DOCTOR"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "milicaperic@gmail.com",
                            Firstname = "Milica",
                            HealthCardNumber = 111154321,
                            Lastname = "Peric",
                            Passwordd = "1234567890",
                            Role = "DOCTOR"
                        },
                        new
                        {
                            UserId = 4,
                            Email = "simonidasimic@gmail.com",
                            Firstname = "Simonida",
                            HealthCardNumber = 982222321,
                            Lastname = "Simic",
                            Passwordd = "1234567890",
                            Role = "DOCTOR"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}