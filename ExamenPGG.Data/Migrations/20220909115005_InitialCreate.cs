using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenPGG.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ThrowsToWin = table.Column<int>(type: "INTEGER", nullable: false),
                    WinnerID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    IconPath = table.Column<string>(type: "varchar(50)", nullable: false),
                    DBGameID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Players_Games_DBGameID",
                        column: x => x.DBGameID,
                        principalTable: "Games",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinnerID",
                table: "Games",
                column: "WinnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_DBGameID",
                table: "Players",
                column: "DBGameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_WinnerID",
                table: "Games",
                column: "WinnerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_WinnerID",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
