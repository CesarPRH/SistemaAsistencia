using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAsistencia.Migrations
{
    /// <inheritdoc />
    public partial class CareerCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoursesCareers",
                columns: table => new
                {
                    IdCourseInCareer = table.Column<Guid>(type: "char(36)", nullable: false),
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CareerId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesInCareers", x => x.IdCourseInCareer);
                    table.ForeignKey(
                        name: "FK_CoursesInCareers_Careers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "Careers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesInCareers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesInCareers_CareerId",
                table: "CoursesCareers",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesInCareers_CourseId",
                table: "CoursesCareers",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesCareers");
        }
    }
}
