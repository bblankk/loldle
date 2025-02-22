using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace loldle.Data.Migrations
{
    public partial class NewChampionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Champion");

            migrationBuilder.AddColumn<string>(
                name: "Positions",
                table: "Champion",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resource",
                table: "Champion",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RangeType",
                table: "Champion",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "Champion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.DropColumn(
                name: "Positions",
                table: "Champion");

            migrationBuilder.DropColumn(
                name: "Resource",
                table: "Champion");

            migrationBuilder.DropColumn(
                name: "RangeType",
                table: "Champion");
        }
    }
}