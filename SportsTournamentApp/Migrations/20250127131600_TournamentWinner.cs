using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTournamentApp.Migrations
{
    /// <inheritdoc />
    public partial class TournamentWinner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WinnerID",
                table: "Tournament",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_WinnerID",
                table: "Tournament",
                column: "WinnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_Team_WinnerID",
                table: "Tournament",
                column: "WinnerID",
                principalTable: "Team",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_Team_WinnerID",
                table: "Tournament");

            migrationBuilder.DropIndex(
                name: "IX_Tournament_WinnerID",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "WinnerID",
                table: "Tournament");
        }
    }
}
