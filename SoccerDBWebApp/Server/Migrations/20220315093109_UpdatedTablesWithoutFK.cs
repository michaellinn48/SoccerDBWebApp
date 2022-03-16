using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerDBWebApp.Server.Migrations
{
    public partial class UpdatedTablesWithoutFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Players",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LeagueId",
                table: "Leagues",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClubId",
                table: "Clubs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CareerHistoryId",
                table: "CareerHistorys",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Players",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Leagues",
                newName: "LeagueId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clubs",
                newName: "ClubId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CareerHistorys",
                newName: "CareerHistoryId");
        }
    }
}
