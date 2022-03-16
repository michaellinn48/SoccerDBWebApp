using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerDBWebApp.Server.Data.Migrations
{
    public partial class TablesWithoutFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CareerHistories",
                table: "CareerHistories");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CareerHistories");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "CareerHistories");

            migrationBuilder.RenameTable(
                name: "CareerHistories",
                newName: "CareerHistorys");

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
                name: "PlayerId",
                table: "CareerHistorys",
                newName: "CareerHistoryId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CareerHistorys",
                newName: "PlayerName");

            migrationBuilder.AlterColumn<int>(
                name: "CareerHistoryId",
                table: "CareerHistorys",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ClubName",
                table: "CareerHistorys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CareerHistorys",
                table: "CareerHistorys",
                column: "CareerHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CareerHistorys",
                table: "CareerHistorys");

            migrationBuilder.DropColumn(
                name: "ClubName",
                table: "CareerHistorys");

            migrationBuilder.RenameTable(
                name: "CareerHistorys",
                newName: "CareerHistories");

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
                name: "PlayerName",
                table: "CareerHistories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CareerHistoryId",
                table: "CareerHistories",
                newName: "PlayerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LeagueId",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "CareerHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CareerHistories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "CareerHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CareerHistories",
                table: "CareerHistories",
                column: "Id");
        }
    }
}
