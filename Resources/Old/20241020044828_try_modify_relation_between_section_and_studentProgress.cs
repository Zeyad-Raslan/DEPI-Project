using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCoursesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class try_modify_relation_between_section_and_studentProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProgresses_Sections_SectionId",
                table: "StudentProgresses");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProgresses_Sections_SectionId",
                table: "StudentProgresses",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "SectionId");
        }
    }
}
