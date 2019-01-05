using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTManagerSutdent.Migrations
{
    public partial class UpdateMark2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Mark_IdMark",
                table: "Mark");

            migrationBuilder.RenameColumn(
                name: "IdMark",
                table: "Mark",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Mark",
                newName: "IdMark");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Mark_IdMark",
                table: "Mark",
                column: "IdMark");
        }
    }
}
