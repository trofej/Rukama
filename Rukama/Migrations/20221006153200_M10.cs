using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class M10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Object",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Object_UserID",
                table: "Object",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Object_AspNetUsers_UserID",
                table: "Object",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Object_AspNetUsers_UserID",
                table: "Object");

            migrationBuilder.DropIndex(
                name: "IX_Object_UserID",
                table: "Object");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Object");
        }
    }
}
