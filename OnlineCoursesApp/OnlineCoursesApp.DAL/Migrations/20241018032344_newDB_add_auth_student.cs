using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCoursesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class newDB_add_auth_student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserID",
                table: "Students",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserID",
                table: "Students",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ApplicationUserID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
