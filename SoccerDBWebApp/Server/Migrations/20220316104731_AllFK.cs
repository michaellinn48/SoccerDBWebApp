using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerDBWebApp.Server.Migrations
{
    public partial class AllFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CareerHistorys_ClubId",
                table: "CareerHistorys",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareerHistorys_Clubs_ClubId",
                table: "CareerHistorys",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerHistorys_Clubs_ClubId",
                table: "CareerHistorys");

            migrationBuilder.DropIndex(
                name: "IX_CareerHistorys_ClubId",
                table: "CareerHistorys");
        }
    }
}
