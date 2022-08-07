using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class InitialCreate24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectSubject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectSubject",
                columns: table => new
                {
                    ObjectsObjectID = table.Column<int>(type: "int", nullable: false),
                    SubjectsSubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectSubject", x => new { x.ObjectsObjectID, x.SubjectsSubjectID });
                    table.ForeignKey(
                        name: "FK_ObjectSubject_Objects_ObjectsObjectID",
                        column: x => x.ObjectsObjectID,
                        principalTable: "Objects",
                        principalColumn: "ObjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectSubject_Subject_SubjectsSubjectID",
                        column: x => x.SubjectsSubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectSubject_SubjectsSubjectID",
                table: "ObjectSubject",
                column: "SubjectsSubjectID");
        }
    }
}
