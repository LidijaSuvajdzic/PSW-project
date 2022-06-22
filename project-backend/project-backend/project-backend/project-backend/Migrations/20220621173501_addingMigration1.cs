using Microsoft.EntityFrameworkCore.Migrations;

namespace project_backend.Migrations
{
    public partial class addingMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "medicaments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "medicaments",
                keyColumn: "Id",
                keyValue: 1,
                column: "quantity",
                value: 200);

            migrationBuilder.UpdateData(
                table: "medicaments",
                keyColumn: "Id",
                keyValue: 2,
                column: "quantity",
                value: 100);

            migrationBuilder.UpdateData(
                table: "medicaments",
                keyColumn: "Id",
                keyValue: 3,
                column: "quantity",
                value: 300);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "medicaments");
        }
    }
}
