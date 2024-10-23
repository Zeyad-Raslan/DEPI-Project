using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCoursesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class newDB_add_auth_instructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "Instructors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_ApplicationUserID",
                table: "Instructors",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_AspNetUsers_ApplicationUserID",
                table: "Instructors",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_AspNetUsers_ApplicationUserID",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_ApplicationUserID",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Instructors");
        }
    }
}
