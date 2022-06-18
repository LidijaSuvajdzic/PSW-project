using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace project_backend.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "freeAppointment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    dateFrom = table.Column<DateTime>(nullable: false),
                    dateTo = table.Column<DateTime>(nullable: false),
                    doctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_freeAppointment", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "freeAppointment",
                columns: new[] { "id", "dateFrom", "dateTo", "doctorId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2022, 6, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2022, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2022, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "userid", "email", "firstname", "healthcardnumber", "lastname", "password", "role" },
                values: new object[,]
                {
                    { 2, "draganaarsin97@gmail.com", "Dragana", 987654321, "Arsin", "1234567890", "DOCTOR" },
                    { 3, "milicaperic@gmail.com", "Milica", 111154321, "Peric", "1234567890", "DOCTOR" },
                    { 4, "simonidasimic@gmail.com", "Simonida", 982222321, "Simic", "1234567890", "DOCTOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "freeAppointment");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "userid",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "userid",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "userid",
                keyValue: 4);
        }
    }
}
