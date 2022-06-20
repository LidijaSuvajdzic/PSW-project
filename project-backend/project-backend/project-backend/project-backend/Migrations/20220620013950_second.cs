using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project_backend.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "freeAppointment",
                columns: new[] { "id", "dateFrom", "dateTo", "doctorId", "isFree" },
                values: new object[,]
                {
                    { 7, new DateTime(2022, 6, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), 5, true },
                    { 8, new DateTime(2022, 3, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 6, true },
                    { 9, new DateTime(2022, 8, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 5, true }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "userid", "email", "firstname", "healthcardnumber", "lastname", "password", "role" },
                values: new object[,]
                {
                    { 5, "milicaperic@gmail.com", "Sanja", 111154321, "Peric", "1234567890", "SPECIALIST" },
                    { 6, "simonidasimic@gmail.com", "Stefan", 982222321, "Simic", "1234567890", "SPECIALIST" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "freeAppointment",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "freeAppointment",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "freeAppointment",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "userid",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "userid",
                keyValue: 6);
        }
    }
}
