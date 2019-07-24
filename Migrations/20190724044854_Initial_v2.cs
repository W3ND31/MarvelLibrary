using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvelLibrary.Migrations
{
    public partial class Initial_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fav_Character_CharacterId",
                table: "Fav");

            migrationBuilder.DropIndex(
                name: "IX_Fav_CharacterId",
                table: "Fav");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Fav_CharacterId",
                table: "Fav",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fav_Character_CharacterId",
                table: "Fav",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
