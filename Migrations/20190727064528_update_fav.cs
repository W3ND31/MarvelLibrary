using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvelLibrary.Migrations
{
    public partial class update_fav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fav",
                table: "Fav");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Fav");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fav",
                table: "Fav",
                columns: new[] { "CharacterId", "AccountLogin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fav",
                table: "Fav");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Fav",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fav",
                table: "Fav",
                columns: new[] { "Id", "CharacterId", "AccountLogin" });
        }
    }
}
