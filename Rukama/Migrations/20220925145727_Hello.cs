using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class Hello : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaxNr",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "FaxNr",
                table: "Object");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FaxNr",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FaxNr",
                table: "Object",
                type: "int",
                nullable: true);
        }
    }
}
