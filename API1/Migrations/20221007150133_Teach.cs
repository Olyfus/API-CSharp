using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API1.Migrations
{
    public partial class Teach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstNaem",
                table: "Teachers",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Teachers",
                newName: "FirstNaem");
        }
    }
}
