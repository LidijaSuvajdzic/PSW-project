using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace project_backend.Migrations
{
    public partial class newOnee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appointmentFeedback",
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
                    table.PrimaryKey("PK_appointmentFeedback", x => x.Id);
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
                name: "hospitalFeedback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    patientId = table.Column<int>(nullable: false),
                    grade = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    isAnonymously = table.Column<bool>(nullable: false),
                    isAPosted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospitalFeedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "penals",
                columns: table => new
                {
                    penalId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    patientId = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_penals", x => x.penalId);
                });

            migrationBuilder.CreateTable(
                name: "prescription",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    patientId = table.Column<int>(nullable: false),
                    doctorId = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    drug = table.Column<string>(nullable: true),
                    usage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescription", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "referrals",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    patientId = table.Column<int>(nullable: false),
                    doctorId = table.Column<int>(nullable: false),
                    specialistId = table.Column<int>(nullable: false),
                    reason = table.Column<string>(nullable: true),
                    dateFrom = table.Column<DateTime>(nullable: false),
                    dateTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_referrals", x => x.id);
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
                    role = table.Column<string>(nullable: true),
                    isBlocked = table.Column<bool>(nullable: false),
                    penals = table.Column<int>(nullable: false),
                    isPotentiallyMalicious = table.Column<bool>(nullable: false)
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
                    { 8, new DateTime(2022, 3, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), 6, true },
                    { 7, new DateTime(2022, 6, 29, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), 5, true },
                    { 6, new DateTime(2022, 8, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, true },
                    { 9, new DateTime(2022, 9, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 5, true },
                    { 4, new DateTime(2022, 7, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), 4, true },
                    { 3, new DateTime(2022, 7, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, true },
                    { 2, new DateTime(2022, 6, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { 5, new DateTime(2022, 3, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 30, 14, 0, 0, 0, DateTimeKind.Unspecified), 2, true }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "userid", "email", "firstname", "healthcardnumber", "isBlocked", "isPotentiallyMalicious", "lastname", "password", "penals", "role" },
                values: new object[,]
                {
                    { 7, "kristina@gmail.com", "Kristina", 111154321, false, false, "Peric", "1234567890", 0, "PATIENT" },
                    { 1, "suvajdziclidija@gmail.com", "Lidija", 1234567890, false, false, "Suvajdzic", "1234567890", 0, "ADMIN" },
                    { 2, "draganaarsin97@gmail.com", "Dragana", 987654321, false, false, "Arsin", "1234567890", 0, "DOCTOR" },
                    { 3, "milicaperic@gmail.com", "Milica", 111154321, false, false, "Peric", "1234567890", 0, "DOCTOR" },
                    { 4, "simonidasimic@gmail.com", "Simonida", 982222321, false, false, "Simic", "1234567890", 0, "DOCTOR" },
                    { 5, "sanja@gmail.com", "Sanja", 111154321, false, false, "Peric", "1234567890", 0, "SPECIALIST" },
                    { 6, "stefan@gmail.com", "Stefan", 982222321, false, false, "Simic", "1234567890", 0, "SPECIALIST" },
                    { 8, "esma@gmail.com", "Esma", 982222321, false, false, "Simic", "1234567890", 0, "PATIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointmentFeedback");

            migrationBuilder.DropTable(
                name: "freeAppointment");

            migrationBuilder.DropTable(
                name: "hospitalFeedback");

            migrationBuilder.DropTable(
                name: "penals");

            migrationBuilder.DropTable(
                name: "prescription");

            migrationBuilder.DropTable(
                name: "referrals");

            migrationBuilder.DropTable(
                name: "reservedAppointment");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
