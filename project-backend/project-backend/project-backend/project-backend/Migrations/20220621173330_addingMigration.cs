using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace project_backend.Migrations
{
    public partial class addingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medicaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "procurements",
                columns: table => new
                {
                    procurementId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    medicamentName = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procurements", x => x.procurementId);
                });

            migrationBuilder.InsertData(
                table: "medicaments",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { 1, "Paracetamol" },
                    { 2, "Diklofen" },
                    { 3, "Brufen" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicaments");

            migrationBuilder.DropTable(
                name: "procurements");
        }
    }
}
