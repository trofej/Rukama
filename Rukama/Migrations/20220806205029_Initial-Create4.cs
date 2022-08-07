using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "Subject",
    columns: table => new
    {
        SubjectID = table.Column<int>(type: "int", nullable: false)
            .Annotation("SqlServer:Identity", "1, 1"),
        SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        LegalForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
        CID = table.Column<int>(type: "int", nullable: false),
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
        ImageURL3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Subject", x => x.SubjectID);

    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
