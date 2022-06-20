using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project_backend.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "freeAppointment",
                columns: new[] { "id", "dateFrom", "dateTo", "doctorId", "isFree" },
                values: new object[] { 6, new DateTime(2022, 8, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "freeAppointment",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
