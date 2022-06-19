using Microsoft.EntityFrameworkCore.Migrations;

namespace project_backend.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFree",
                table: "freeAppointment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "freeAppointment",
                keyColumn: "id",
                keyValue: 1,
                column: "isFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "freeAppointment",
                keyColumn: "id",
                keyValue: 2,
                column: "isFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "freeAppointment",
                keyColumn: "id",
                keyValue: 3,
                column: "isFree",
                value: true);

            migrationBuilder.UpdateData(
                table: "freeAppointment",
                keyColumn: "id",
                keyValue: 4,
                column: "isFree",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFree",
                table: "freeAppointment");
        }
    }
}
