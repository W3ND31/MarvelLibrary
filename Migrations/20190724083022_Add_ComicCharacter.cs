using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvelLibrary.Migrations
{
    public partial class Add_ComicCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComicCharacter",
                columns: table => new
                {
                    ComicId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicCharacter", x => new { x.ComicId, x.CharacterId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComicCharacter");
        }
    }
}
