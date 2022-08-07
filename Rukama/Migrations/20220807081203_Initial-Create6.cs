using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class InitialCreate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CID = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxNr = table.Column<int>(type: "int", nullable: true),
                    GPS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageURL3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNr = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpeningHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneNr = table.Column<int>(type: "int", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectID);
                });

                migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
