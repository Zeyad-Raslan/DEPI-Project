using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCoursesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class newDB_add_auth_admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "WebAdmins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WebAdmins_ApplicationUserID",
                table: "WebAdmins",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_WebAdmins_AspNetUsers_ApplicationUserID",
                table: "WebAdmins",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebAdmins_AspNetUsers_ApplicationUserID",
                table: "WebAdmins");

            migrationBuilder.DropIndex(
                name: "IX_WebAdmins_ApplicationUserID",
                table: "WebAdmins");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "WebAdmins");
        }
    }
}
