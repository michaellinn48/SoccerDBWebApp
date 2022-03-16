using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerDBWebApp.Server.Migrations
{
    public partial class FKTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "Clubs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "CareerHistorys",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "CareerHistorys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_LeagueId",
                table: "Clubs",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_CareerHistorys_PlayerId",
                table: "CareerHistorys",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareerHistorys_Players_PlayerId",
                table: "CareerHistorys",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Leagues_LeagueId",
                table: "Clubs",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerHistorys_Players_PlayerId",
                table: "CareerHistorys");

            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Leagues_LeagueId",
                table: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_LeagueId",
                table: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_CareerHistorys_PlayerId",
                table: "CareerHistorys");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "CareerHistorys");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "CareerHistorys");
        }
    }
}
