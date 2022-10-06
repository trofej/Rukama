using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
    name: "UserId",
    table: "AspNetUsers",
    newName: "Id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
