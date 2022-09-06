using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class Specialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    SpecializationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.SpecializationID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropColumn(
                name: "ImagePath1",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "ImagePath2",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "ImagePath3",
                table: "Subject");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Subject",
                newName: "ImageURL3");

            migrationBuilder.RenameColumn(
                name: "ImagePath3",
                table: "Object",
                newName: "ImageURL3");

            migrationBuilder.RenameColumn(
                name: "ImagePath2",
                table: "Object",
                newName: "ImageURL2");

            migrationBuilder.RenameColumn(
                name: "ImagePath1",
                table: "Object",
                newName: "ImageURL1");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Object",
                newName: "IconURL");

            migrationBuilder.AddColumn<string>(
                name: "IconURL",
                table: "Subject",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL1",
                table: "Subject",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL2",
                table: "Subject",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Establishment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establishment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Establishment_Object_ObjectID",
                        column: x => x.ObjectID,
                        principalTable: "Object",
                        principalColumn: "ObjectID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Establishment_ObjectID",
                table: "Establishment",
                column: "ObjectID");
        }
    }
}
