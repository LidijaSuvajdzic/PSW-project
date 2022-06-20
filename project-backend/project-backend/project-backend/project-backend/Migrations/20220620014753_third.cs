using Microsoft.EntityFrameworkCore.Migrations;

namespace project_backend.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 5,
                column: "email",
                value: "sanja@gmail.com");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 6,
                column: "email",
                value: "stefan@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 5,
                column: "email",
                value: "milicaperic@gmail.com");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userid",
                keyValue: 6,
                column: "email",
                value: "simonidasimic@gmail.com");
        }
    }
}
