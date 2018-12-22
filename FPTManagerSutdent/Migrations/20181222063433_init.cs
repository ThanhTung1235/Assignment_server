using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTManagerSutdent.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassRoom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ExpiredAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Rollnumber = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    DoB = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Rollnumber);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassRoomCourse",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    ClassRoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoomCourse", x => new { x.CourseId, x.ClassRoomId });
                    table.ForeignKey(
                        name: "FK_ClassRoomCourse_ClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRoomCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mark",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Theory = table.Column<int>(nullable: false),
                    Practice = table.Column<int>(nullable: false),
                    Assignment = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    StudentRollnumber = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mark_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mark_Student_StudentRollnumber",
                        column: x => x.StudentRollnumber,
                        principalTable: "Student",
                        principalColumn: "Rollnumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentClassRoom",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    StudentRollnumber = table.Column<long>(nullable: true),
                    ClassRoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassRoom", x => new { x.ClassId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentClassRoom_ClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentClassRoom_Student_StudentRollnumber",
                        column: x => x.StudentRollnumber,
                        principalTable: "Student",
                        principalColumn: "Rollnumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    StudentRollnumber = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Student_StudentRollnumber",
                        column: x => x.StudentRollnumber,
                        principalTable: "Student",
                        principalColumn: "Rollnumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoomCourse_ClassRoomId",
                table: "ClassRoomCourse",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_CourseId",
                table: "Mark",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_StudentRollnumber",
                table: "Mark",
                column: "StudentRollnumber");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassRoom_ClassRoomId",
                table: "StudentClassRoom",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassRoom_StudentRollnumber",
                table: "StudentClassRoom",
                column: "StudentRollnumber");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentRollnumber",
                table: "StudentCourse",
                column: "StudentRollnumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassRoomCourse");

            migrationBuilder.DropTable(
                name: "Mark");

            migrationBuilder.DropTable(
                name: "StudentClassRoom");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "ClassRoom");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
