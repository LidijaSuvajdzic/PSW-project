using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project_backend.Migrations
{
    public partial class druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DeleteData(
                table: "freeAppointment",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "freeAppointment",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "freeAppointment",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "freeAppointment",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "freeAppointment",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "userid",
                keyValue: 1);

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
