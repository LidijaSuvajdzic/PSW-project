using Microsoft.EntityFrameworkCore.Migrations;

namespace project_backend.Migrations
{
    public partial class next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "userid", "email", "firstname", "healthcardnumber", "lastname", "password", "role" },
                values: new object[,]
                {
                    { 7, "kristina@gmail.com", "Kristina", 111154321, "Peric", "1234567890", "PATIENT" },
                    { 8, "esma@gmail.com", "Esma", 982222321, "Simic", "1234567890", "PATIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "userid",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "userid",
                keyValue: 8);
        }
    }
}
