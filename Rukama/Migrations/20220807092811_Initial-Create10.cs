using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rukama.Migrations
{
    public partial class InitialCreate10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Subject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Subject",
                type: "datetime2",
                nullable: true);
        }
    }
}
