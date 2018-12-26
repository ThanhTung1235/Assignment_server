using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTManagerSutdent.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Account_AccountId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_AccountId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Teacher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Teacher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_AccountId",
                table: "Teacher",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Account_AccountId",
                table: "Teacher",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
