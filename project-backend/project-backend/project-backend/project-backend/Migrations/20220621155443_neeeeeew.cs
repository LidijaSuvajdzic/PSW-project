using Microsoft.EntityFrameworkCore.Migrations;

namespace project_backend.Migrations
{
    public partial class neeeeeew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 1,
                column: "role",
                value: "ROLE_ADMIN");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 2,
                column: "role",
                value: "ROLE_DOCTOR");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 3,
                column: "role",
                value: "ROLE_DOCTOR");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 4,
                column: "role",
                value: "ROLE_DOCTOR");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 5,
                column: "role",
                value: "ROLE_SPECIALIST");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 6,
                column: "role",
                value: "ROLE_SPECIALIST");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 7,
                column: "role",
                value: "ROLE_PATIENT");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 8,
                column: "role",
                value: "ROLE_PATIENT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 1,
                column: "role",
                value: "ADMIN");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 2,
                column: "role",
                value: "DOCTOR");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 3,
                column: "role",
                value: "DOCTOR");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 4,
                column: "role",
                value: "DOCTOR");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 5,
                column: "role",
                value: "SPECIALIST");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 6,
                column: "role",
                value: "SPECIALIST");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 7,
                column: "role",
                value: "PATIENT");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 8,
                column: "role",
                value: "PATIENT");
        }
    }
}
