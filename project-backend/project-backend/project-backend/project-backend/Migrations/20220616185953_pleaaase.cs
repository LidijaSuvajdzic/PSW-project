using Microsoft.EntityFrameworkCore.Migrations;

namespace project_backend.Migrations
{
    public partial class pleaaase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "users",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "users",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "HealthCardNumber",
                table: "users",
                newName: "healthcardnumber");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "users",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "users",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "Passwordd",
                table: "users",
                newName: "password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "users",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "healthcardnumber",
                table: "users",
                newName: "HealthCardNumber");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "users",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "Passwordd");
        }
    }
}
