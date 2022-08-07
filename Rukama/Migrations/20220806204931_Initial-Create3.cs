using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropForeignKey(
    name: "FK_Establishment_Subject_SubjectID",
    table: "Establishment");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_AspNetUsers_UserID",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_UserID",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Establishment_SubjectID",
                table: "Establishment");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "Establishment");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Subject",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "Establishment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_UserID",
                table: "Subject",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Establishment_SubjectID",
                table: "Establishment",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Establishment_Subject_SubjectID",
                table: "Establishment",
                column: "SubjectID",
                principalTable: "Subject",
                principalColumn: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_AspNetUsers_UserID",
                table: "Subject",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
