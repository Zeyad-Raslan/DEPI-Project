using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCoursesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingSectionToStudentProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "StudentProgresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgresses_SectionId",
                table: "StudentProgresses",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProgresses_Sections_SectionId",
                table: "StudentProgresses",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProgresses_Sections_SectionId",
                table: "StudentProgresses");

            migrationBuilder.DropIndex(
                name: "IX_StudentProgresses_SectionId",
                table: "StudentProgresses");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "StudentProgresses");
        }
    }
}
