using Microsoft.EntityFrameworkCore.Migrations;

namespace Darts.Server.Migrations
{
    public partial class AddingThrownDartsToTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "player_Id",
                table: "UserModels",
                newName: "Player_Id");

            migrationBuilder.AddColumn<int>(
                name: "ThrownDarts",
                table: "Teams",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThrownDarts",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "Player_Id",
                table: "UserModels",
                newName: "player_Id");
        }
    }
}
