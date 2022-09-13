using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenPGG.Data.Migrations
{
    public partial class NullablePlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_PlayerID",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerID",
                table: "Games",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_PlayerID",
                table: "Games",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_PlayerID",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerID",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_PlayerID",
                table: "Games",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}