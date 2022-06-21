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
    [Migration("20220621113554_caoo")]
    partial class caoo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("project_backend.Models.AppointmentFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<int>("AppointmentId")
                        .HasColumnName("appointmentId");

                    b.Property<string>("Comment")
                        .HasColumnName("comment");

                    b.Property<int>("Grade")
                        .HasColumnName("grade");

                    b.Property<int>("PatientId")
                        .HasColumnName("patientId");

                    b.HasKey("Id");

                    b.ToTable("appointmentFeedback");
                });

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
                            DateFrom = new DateTime(2022, 7, 25, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2022, 7, 25, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 3,
                            IsFree = true
                        },
                        new
                        {
                            Id = 4,
                            DateFrom = new DateTime(2022, 7, 26, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2022, 7, 26, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 4,
                            IsFree = true
                        },
                        new
                        {
                            Id = 5,
                            DateFrom = new DateTime(2022, 3, 30, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2022, 3, 30, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 2,
                            IsFree = true
                        },
                        new
                        {
                            Id = 6,
                            DateFrom = new DateTime(2022, 8, 20, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2022, 8, 20, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 3,
                            IsFree = true
                        },
                        new
                        {
                            Id = 7,
                            DateFrom = new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2022, 6, 29, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 5,
                            IsFree = true
                        },
                        new
                        {
                            Id = 8,
                            DateFrom = new DateTime(2022, 3, 22, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2022, 3, 22, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 6,
                            IsFree = true
                        },
                        new
                        {
                            Id = 9,
                            DateFrom = new DateTime(2022, 9, 20, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2022, 9, 20, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 5,
                            IsFree = true
                        });
                });

            modelBuilder.Entity("project_backend.Models.HospitalFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Comment")
                        .HasColumnName("comment");

                    b.Property<int>("Grade")
                        .HasColumnName("grade");

                    b.Property<bool>("IsAnonymously")
                        .HasColumnName("isAnonymously");

                    b.Property<bool>("IsPosted")
                        .HasColumnName("isAPosted");

                    b.Property<int>("PatientId")
                        .HasColumnName("patientId");

                    b.HasKey("Id");

                    b.ToTable("hospitalFeedback");
                });

            modelBuilder.Entity("project_backend.Models.Penal", b =>
                {
                    b.Property<int>("PenalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("penalId");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date");

                    b.Property<int>("PatientId")
                        .HasColumnName("patientId");

                    b.HasKey("PenalId");

                    b.ToTable("penals");
                });

            modelBuilder.Entity("project_backend.Models.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date");

                    b.Property<int>("DoctorId")
                        .HasColumnName("doctorId");

                    b.Property<string>("Drug")
                        .HasColumnName("drug");

                    b.Property<int>("PatientId")
                        .HasColumnName("patientId");

                    b.Property<string>("Usage")
                        .HasColumnName("usage");

                    b.HasKey("Id");

                    b.ToTable("prescription");
                });

            modelBuilder.Entity("project_backend.Models.Referral", b =>
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

                    b.Property<int>("PatientId")
                        .HasColumnName("patientId");

                    b.Property<string>("Reason")
                        .HasColumnName("reason");

                    b.Property<int>("SpecialistId")
                        .HasColumnName("specialistId");

                    b.HasKey("Id");

                    b.ToTable("referrals");
                });

            modelBuilder.Entity("project_backend.Models.ReservedAppointment", b =>
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

                    b.Property<bool>("IsRated")
                        .HasColumnName("isRated");

                    b.Property<int>("PatientId")
                        .HasColumnName("patientId");

                    b.HasKey("Id");

                    b.ToTable("reservedAppointment");
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

                    b.Property<bool>("IsBlocked")
                        .HasColumnName("isBlocked");

                    b.Property<bool>("IsPotentiallyMalicious")
                        .HasColumnName("isPotentiallyMalicious");

                    b.Property<string>("Lastname")
                        .HasColumnName("lastname");

                    b.Property<string>("Passwordd")
                        .HasColumnName("password");

                    b.Property<int>("Penals")
                        .HasColumnName("penals");

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
                            IsBlocked = false,
                            IsPotentiallyMalicious = false,
                            Lastname = "Suvajdzic",
                            Passwordd = "1234567890",
                            Penals = 0,
                            Role = "ADMIN"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "draganaarsin97@gmail.com",
                            Firstname = "Dragana",
                            HealthCardNumber = 987654321,
                            IsBlocked = false,
                            IsPotentiallyMalicious = false,
                            Lastname = "Arsin",
                            Passwordd = "1234567890",
                            Penals = 0,
                            Role = "DOCTOR"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "milicaperic@gmail.com",
                            Firstname = "Milica",
                            HealthCardNumber = 111154321,
                            IsBlocked = false,
                            IsPotentiallyMalicious = false,
                            Lastname = "Peric",
                            Passwordd = "1234567890",
                            Penals = 0,
                            Role = "DOCTOR"
                        },
                        new
                        {
                            UserId = 4,
                            Email = "simonidasimic@gmail.com",
                            Firstname = "Simonida",
                            HealthCardNumber = 982222321,
                            IsBlocked = false,
                            IsPotentiallyMalicious = false,
                            Lastname = "Simic",
                            Passwordd = "1234567890",
                            Penals = 0,
                            Role = "DOCTOR"
                        },
                        new
                        {
                            UserId = 5,
                            Email = "sanja@gmail.com",
                            Firstname = "Sanja",
                            HealthCardNumber = 111154321,
                            IsBlocked = false,
                            IsPotentiallyMalicious = false,
                            Lastname = "Peric",
                            Passwordd = "1234567890",
                            Penals = 0,
                            Role = "SPECIALIST"
                        },
                        new
                        {
                            UserId = 6,
                            Email = "stefan@gmail.com",
                            Firstname = "Stefan",
                            HealthCardNumber = 982222321,
                            IsBlocked = false,
                            IsPotentiallyMalicious = false,
                            Lastname = "Simic",
                            Passwordd = "1234567890",
                            Penals = 0,
                            Role = "SPECIALIST"
                        },
                        new
                        {
                            UserId = 7,
                            Email = "kristina@gmail.com",
                            Firstname = "Kristina",
                            HealthCardNumber = 111154321,
                            IsBlocked = false,
                            IsPotentiallyMalicious = false,
                            Lastname = "Peric",
                            Passwordd = "1234567890",
                            Penals = 0,
                            Role = "PATIENT"
                        },
                        new
                        {
                            UserId = 8,
                            Email = "esma@gmail.com",
                            Firstname = "Esma",
                            HealthCardNumber = 982222321,
                            IsBlocked = false,
                            IsPotentiallyMalicious = false,
                            Lastname = "Simic",
                            Passwordd = "1234567890",
                            Penals = 0,
                            Role = "PATIENT"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
