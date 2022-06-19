using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace project_backend.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appointmentFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    patientId = table.Column<int>(nullable: false),
                    grade = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    appointmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointmentFeedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "freeAppointment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    dateFrom = table.Column<DateTime>(nullable: false),
                    dateTo = table.Column<DateTime>(nullable: false),
                    doctorId = table.Column<int>(nullable: false),
                    isFree = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_freeAppointment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hospitalFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    patientId = table.Column<int>(nullable: false),
                    grade = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    isAnonymously = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospitalFeedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reservedAppointment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    dateFrom = table.Column<DateTime>(nullable: false),
                    dateTo = table.Column<DateTime>(nullable: false),
                    doctorId = table.Column<int>(nullable: false),
                    patientId = table.Column<int>(nullable: false),
                    isRated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservedAppointment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    firstname = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    healthcardnumber = table.Column<int>(nullable: false),
                    role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userid);
                });

            migrationBuilder.InsertData(
                table: "freeAppointment",
                columns: new[] { "id", "dateFrom", "dateTo", "doctorId", "isFree" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { 2, new DateTime(2022, 6, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { 3, new DateTime(2022, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, true },
                    { 4, new DateTime(2022, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), 4, true },
                    { 5, new DateTime(2022, 3, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, true }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "userid", "email", "firstname", "healthcardnumber", "lastname", "password", "role" },
                values: new object[,]
                {
                    { 1, "suvajdziclidija@gmail.com", "Lidija", 1234567890, "Suvajdzic", "1234567890", "ADMIN" },
                    { 2, "draganaarsin97@gmail.com", "Dragana", 987654321, "Arsin", "1234567890", "DOCTOR" },
                    { 3, "milicaperic@gmail.com", "Milica", 111154321, "Peric", "1234567890", "DOCTOR" },
                    { 4, "simonidasimic@gmail.com", "Simonida", 982222321, "Simic", "1234567890", "DOCTOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointmentFeedbacks");

            migrationBuilder.DropTable(
                name: "freeAppointment");

            migrationBuilder.DropTable(
                name: "hospitalFeedbacks");

            migrationBuilder.DropTable(
                name: "reservedAppointment");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
