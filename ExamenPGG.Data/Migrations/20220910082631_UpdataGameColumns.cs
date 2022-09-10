using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenPGG.Data.Migrations
{
    public partial class UpdataGameColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_WinnerID",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "WinnerID",
                table: "Games",
                newName: "PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_Games_WinnerID",
                table: "Games",
                newName: "IX_Games_PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_PlayerID",
                table: "Games",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_PlayerID",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "PlayerID",
                table: "Games",
                newName: "WinnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Games_PlayerID",
                table: "Games",
                newName: "IX_Games_WinnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_WinnerID",
                table: "Games",
                column: "WinnerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
