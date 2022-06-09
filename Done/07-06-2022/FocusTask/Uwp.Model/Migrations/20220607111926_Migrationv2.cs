using Microsoft.EntityFrameworkCore.Migrations;

namespace Uwp.SQLite.Model.Migrations
{
    public partial class Migrationv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInformed",
                table: "Missions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SubMissionId",
                table: "Missions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInformed",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "SubMissionId",
                table: "Missions");
        }
    }
}
