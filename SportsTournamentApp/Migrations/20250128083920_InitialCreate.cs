using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsTournamentApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_Team_WinnerID",
                table: "Tournament");

            migrationBuilder.RenameColumn(
                name: "WinnerID",
                table: "Tournament",
                newName: "WinningTeamID");

            migrationBuilder.RenameIndex(
                name: "IX_Tournament_WinnerID",
                table: "Tournament",
                newName: "IX_Tournament_WinningTeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_Team_WinningTeamID",
                table: "Tournament",
                column: "WinningTeamID",
                principalTable: "Team",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_Team_WinningTeamID",
                table: "Tournament");

            migrationBuilder.RenameColumn(
                name: "WinningTeamID",
                table: "Tournament",
                newName: "WinnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Tournament_WinningTeamID",
                table: "Tournament",
                newName: "IX_Tournament_WinnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_Team_WinnerID",
                table: "Tournament",
                column: "WinnerID",
                principalTable: "Team",
                principalColumn: "ID");
        }
    }
}
