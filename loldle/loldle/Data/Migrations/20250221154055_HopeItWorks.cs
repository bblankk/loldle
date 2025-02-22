using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace loldle.Data.Migrations
{
    /// <inheritdoc />
    public partial class HopeItWorks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Positions",
                table: "Champion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RangeType",
                table: "Champion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "Champion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Resource",
                table: "Champion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Positions",
                table: "Champion");

            migrationBuilder.DropColumn(
                name: "RangeType",
                table: "Champion");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Champion");

            migrationBuilder.DropColumn(
                name: "Resource",
                table: "Champion");
        }
    }
}
