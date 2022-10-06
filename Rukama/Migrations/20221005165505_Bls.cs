using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class Bls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_AspNetUsers_UserID",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_UserID",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Subject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Subject",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_UserID",
                table: "Subject",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_AspNetUsers_UserID",
                table: "Subject",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
