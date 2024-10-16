using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCoursesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingCourseStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseStatus",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseStatus",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Courses",
                type: "int",
                nullable: true);
        }
    }
}
