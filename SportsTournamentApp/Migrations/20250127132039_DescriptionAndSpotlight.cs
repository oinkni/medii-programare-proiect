using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTournamentApp.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionAndSpotlight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tournament",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Spotlight",
                table: "Tournament",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Team",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "Spotlight",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Team");
        }
    }
}
