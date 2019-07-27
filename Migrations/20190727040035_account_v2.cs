using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvelLibrary.Migrations
{
    public partial class account_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fav",
                table: "Fav");

            migrationBuilder.AddColumn<string>(
                name: "AccountLogin",
                table: "Fav",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fav",
                table: "Fav",
                columns: new[] { "Id", "CharacterId", "AccountLogin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fav",
                table: "Fav");

            migrationBuilder.DropColumn(
                name: "AccountLogin",
                table: "Fav");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fav",
                table: "Fav",
                columns: new[] { "Id", "CharacterId" });
        }
    }
}
