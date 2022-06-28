using Microsoft.EntityFrameworkCore.Migrations;

namespace Uwp.SQLite.Model.Migrations
{
    public partial class UpdateMigration_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFavorite",
                table: "Topics",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFavorite",
                table: "Topics");
        }
    }
}
