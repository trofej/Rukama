using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class InitialCreate25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Joke");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropForeignKey(
                name: "FK_Establishment_Object_ObjectID",
                table: "Establishment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Object",
                table: "Object");

            migrationBuilder.RenameTable(
                name: "Object",
                newName: "Objects");

            migrationBuilder.AddColumn<int>(
                name: "CID",
                table: "Objects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objects",
                table: "Objects",
                column: "ObjectID");

            migrationBuilder.CreateTable(
                name: "Joke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JokeAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JokeQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joke", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Establishment_Objects_ObjectID",
                table: "Establishment",
                column: "ObjectID",
                principalTable: "Objects",
                principalColumn: "ObjectID");
        }
    }
}
