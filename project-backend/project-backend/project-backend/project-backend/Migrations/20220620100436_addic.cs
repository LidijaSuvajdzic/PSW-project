using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace project_backend.Migrations
{
    public partial class addic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dateFrom",
                table: "referrals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTo",
                table: "referrals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateFrom",
                table: "referrals");

            migrationBuilder.DropColumn(
                name: "dateTo",
                table: "referrals");
        }
    }
}
