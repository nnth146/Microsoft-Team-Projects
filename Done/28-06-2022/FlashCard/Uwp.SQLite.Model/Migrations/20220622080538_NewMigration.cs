using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Uwp.SQLite.Model.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    FolderModelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Create_On = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.FolderModelId);
                });

            migrationBuilder.CreateTable(
                name: "Studies",
                columns: table => new
                {
                    StudyModelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Create_On = table.Column<DateTime>(nullable: false),
                    FolderModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studies", x => x.StudyModelId);
                    table.ForeignKey(
                        name: "FK_Studies_Folders_FolderModelId",
                        column: x => x.FolderModelId,
                        principalTable: "Folders",
                        principalColumn: "FolderModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicModelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Defination = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    hasItem = table.Column<bool>(nullable: false),
                    StudyModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicModelId);
                    table.ForeignKey(
                        name: "FK_Topics_Studies_StudyModelId",
                        column: x => x.StudyModelId,
                        principalTable: "Studies",
                        principalColumn: "StudyModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studies_FolderModelId",
                table: "Studies",
                column: "FolderModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_StudyModelId",
                table: "Topics",
                column: "StudyModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Studies");

            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
