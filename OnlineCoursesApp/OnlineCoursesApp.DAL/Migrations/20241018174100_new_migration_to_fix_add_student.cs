using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCoursesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class new_migration_to_fix_add_student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_AspNetUsers_ApplicationUserID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_WebAdmins_AspNetUsers_ApplicationUserID",
                table: "WebAdmins");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "WebAdmins",
                newName: "IdentityUserID");

            migrationBuilder.RenameIndex(
                name: "IX_WebAdmins_ApplicationUserID",
                table: "WebAdmins",
                newName: "IX_WebAdmins_IdentityUserID");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Students",
                newName: "IdentityUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ApplicationUserID",
                table: "Students",
                newName: "IX_Students_IdentityUserID");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Instructors",
                newName: "IdentityUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_ApplicationUserID",
                table: "Instructors",
                newName: "IX_Instructors_IdentityUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_AspNetUsers_IdentityUserID",
                table: "Instructors",
                column: "IdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_IdentityUserID",
                table: "Students",
                column: "IdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WebAdmins_AspNetUsers_IdentityUserID",
                table: "WebAdmins",
                column: "IdentityUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_AspNetUsers_IdentityUserID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_IdentityUserID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_WebAdmins_AspNetUsers_IdentityUserID",
                table: "WebAdmins");

            migrationBuilder.RenameColumn(
                name: "IdentityUserID",
                table: "WebAdmins",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_WebAdmins_IdentityUserID",
                table: "WebAdmins",
                newName: "IX_WebAdmins_ApplicationUserID");

            migrationBuilder.RenameColumn(
                name: "IdentityUserID",
                table: "Students",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_IdentityUserID",
                table: "Students",
                newName: "IX_Students_ApplicationUserID");

            migrationBuilder.RenameColumn(
                name: "IdentityUserID",
                table: "Instructors",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_IdentityUserID",
                table: "Instructors",
                newName: "IX_Instructors_ApplicationUserID");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_AspNetUsers_ApplicationUserID",
                table: "Instructors",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserID",
                table: "Students",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WebAdmins_AspNetUsers_ApplicationUserID",
                table: "WebAdmins",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
