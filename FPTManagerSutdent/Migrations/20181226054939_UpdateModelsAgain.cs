using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTManagerSutdent.Migrations
{
    public partial class UpdateModelsAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Account_AccountId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Student_AccountId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_AccountId",
                table: "Student",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Account_AccountId",
                table: "Student",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
