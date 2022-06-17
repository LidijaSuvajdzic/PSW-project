﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using project_backend.Models;

namespace project_backend.Migrations
{
    [DbContext(typeof(MyWebApiContext))]
    [Migration("20220616172508_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("project_backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Firstname");

                    b.Property<int>("HealthCardNumber");

                    b.Property<string>("Lastname");

                    b.Property<string>("Passwordd");

                    b.Property<string>("Role");

                    b.HasKey("UserId");

                    b.ToTable("Users");

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
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
