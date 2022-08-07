using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class InitialCreate20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Subject",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_UserID",
                table: "Subject",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_AspNetUsers_UserID",
                table: "Subject",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_AspNetUsers_UserId",
                table: "Subject");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Subject",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_AspNetUsers_UserId",
                table: "Subject",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
