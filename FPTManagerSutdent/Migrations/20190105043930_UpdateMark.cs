using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTManagerSutdent.Migrations
{
    public partial class UpdateMark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Mark_Id",
                table: "Mark");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Mark");

            migrationBuilder.RenameColumn(
                name: "TypeMark",
                table: "Mark",
                newName: "IdMark");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Mark_IdMark",
                table: "Mark",
                column: "IdMark");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Mark_IdMark",
                table: "Mark");

            migrationBuilder.RenameColumn(
                name: "IdMark",
                table: "Mark",
                newName: "TypeMark");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Mark",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Mark_Id",
                table: "Mark",
                column: "Id");
        }
    }
}
