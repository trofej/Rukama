using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class InitialCreate21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_AspNetUsers_UserId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_UserId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Subject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Subject",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_UserId",
                table: "Subject",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_AspNetUsers_UserId",
                table: "Subject",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
