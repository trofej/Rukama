using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class InitialCreate22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                    migrationBuilder.CreateTable(
            name: "Object",
            columns: table => new
            {
                ObjectID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ObjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                GPS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                StreetNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                MobileNr = table.Column<int>(type: "int", nullable: true),
                TelephoneNr = table.Column<int>(type: "int", nullable: true),
                FaxNr = table.Column<int>(type: "int", nullable: true),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                OpeningHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                IconURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImageURL1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImageURL2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ImageURL3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Object", x => x.ObjectID);
            });

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
                        name: "FK_ObjectSubject_Object_ObjectsObjectID",
                        column: x => x.ObjectsObjectID,
                        principalTable: "Object",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectSubject");

            migrationBuilder.DropColumn(
                name: "CID",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Objects");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Objects",
                newName: "CreationTime");

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Objects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectType",
                table: "Objects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectName",
                table: "Objects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GPS",
                table: "Objects",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Objects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_UserID",
                table: "Objects",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_AspNetUsers_UserID",
                table: "Objects",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropForeignKey(
    name: "FK_Objects_AspNetUsers_UserID",
    table: "Objects");

            migrationBuilder.DropIndex(
                name: "IX_Objects_UserID",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Objects");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Objects",
                newName: "CreationDate");

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Objects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ObjectType",
                table: "Objects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "ObjectName",
                table: "Objects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "GPS",
                table: "Objects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048);

            migrationBuilder.AddColumn<int>(
                name: "CID",
                table: "Objects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Objects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
