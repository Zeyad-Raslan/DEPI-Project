using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineCoursesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seed_data_edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cdeb8a86-2e9d-4a9a-8ce1-109ea23e4548", "17af0400-b581-4b23-8111-32a4a52253ed" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c1adbe82-f222-45c3-8d82-0c454a224ef4", "6a496927-5dba-4961-9f6e-42872c6927b4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d3616ae7-5298-460e-ac3a-62a9671142cf", "6a496927-5dba-4961-9f6e-42872c6927b4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bae23c41-26cf-4c8e-9242-cde163417374", "ebee14af-cd79-485a-9fc5-19a3cdba3985" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cdeb8a86-2e9d-4a9a-8ce1-109ea23e4548", "ebee14af-cd79-485a-9fc5-19a3cdba3985" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a33f1ee-c52a-42b8-a40b-48b6b7da0968");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bae23c41-26cf-4c8e-9242-cde163417374");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1adbe82-f222-45c3-8d82-0c454a224ef4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdeb8a86-2e9d-4a9a-8ce1-109ea23e4548");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3616ae7-5298-460e-ac3a-62a9671142cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17af0400-b581-4b23-8111-32a4a52253ed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a496927-5dba-4961-9f6e-42872c6927b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebee14af-cd79-485a-9fc5-19a3cdba3985");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07b1b30f-66b6-491b-a1dc-ad6d4b04dd7a", null, "Instructor", "INSTRUCTOR" },
                    { "2f03cdd5-eaf0-4157-9af1-be8c0df9ab0e", null, "Student", "STUDENT" },
                    { "7e00e739-1ed8-48b3-8478-ed643d0fa2be", null, "SuperAdmin", "SUPERADMIN" },
                    { "e0dd8eda-27d1-4173-a5a9-db95069e6f5b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "215fe811-4ff2-4532-84ce-79478b535e59", 0, "d3b88e66-6bb5-4df3-926b-1674f2c8acc5", "superAdmin@mail.com", true, false, null, "SUPERADMIN@MAIL.COM", "SUPERADMIN@MAIL.COM", "AQAAAAIAAYagAAAAENe7nduGFY0/TzRCdDVy3gWvDl+lnWzG4MuJfRJj/fTX95lXsKoSCzvRJT5LF4alvg==", null, false, "2761de31-1933-4ac3-8a25-44777b29b417", false, "superAdmin@mail.com" },
                    { "2b208662-b6f3-44b4-b1c1-6913585b9802", 0, "b4f6db70-8e6c-4f12-aeb4-92b1b86df8a2", "instructor@mail.com", true, false, null, "INSTRUCTOR@MAIL.COM", "INSTRUCTOR@MAIL.COM", "AQAAAAIAAYagAAAAED6Cm/ggoAUjyWc5K/uhvtd18154OAG9E6Br29iW83f/x/cRYa2TtfKXtSUwe7GrSQ==", null, false, "3b0bf16f-b405-431d-86b4-a2fb9969e1a4", false, "instructor@mail.com" },
                    { "9423a267-b27e-4e29-811e-bda9fd34641c", 0, "ddb361c6-80b9-4719-a1f5-cf9cd00971cc", "student@mail.com", true, false, null, "STUDENT@MAIL.COM", "STUDENT@MAIL.COM", "AQAAAAIAAYagAAAAEIU8gFC0rbwqogh4WrIz47BQKT54giVYn5oy+nngOATV4z7dU2fGGHmY4yU7ro0zqg==", null, false, "0c01024a-244d-487a-b7c0-a2dc06215eb2", false, "student@mail.com" },
                    { "a5fc2efa-8c94-4a19-aa54-fef1dd61b93b", 0, "61ff3a91-4800-47c5-8340-78fbd04ca94f", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEAsdZw3Ez5KJ/9og98YDNkFqsC5YcR709Qos1rHVOQ2Jy1KroM4QH4PSPmwmjCM9mw==", null, false, "6fb394c1-145d-4892-9b3c-418bdeb4e242", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7e00e739-1ed8-48b3-8478-ed643d0fa2be", "215fe811-4ff2-4532-84ce-79478b535e59" },
                    { "e0dd8eda-27d1-4173-a5a9-db95069e6f5b", "215fe811-4ff2-4532-84ce-79478b535e59" },
                    { "07b1b30f-66b6-491b-a1dc-ad6d4b04dd7a", "2b208662-b6f3-44b4-b1c1-6913585b9802" },
                    { "2f03cdd5-eaf0-4157-9af1-be8c0df9ab0e", "9423a267-b27e-4e29-811e-bda9fd34641c" },
                    { "e0dd8eda-27d1-4173-a5a9-db95069e6f5b", "a5fc2efa-8c94-4a19-aa54-fef1dd61b93b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7e00e739-1ed8-48b3-8478-ed643d0fa2be", "215fe811-4ff2-4532-84ce-79478b535e59" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e0dd8eda-27d1-4173-a5a9-db95069e6f5b", "215fe811-4ff2-4532-84ce-79478b535e59" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "07b1b30f-66b6-491b-a1dc-ad6d4b04dd7a", "2b208662-b6f3-44b4-b1c1-6913585b9802" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2f03cdd5-eaf0-4157-9af1-be8c0df9ab0e", "9423a267-b27e-4e29-811e-bda9fd34641c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e0dd8eda-27d1-4173-a5a9-db95069e6f5b", "a5fc2efa-8c94-4a19-aa54-fef1dd61b93b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07b1b30f-66b6-491b-a1dc-ad6d4b04dd7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f03cdd5-eaf0-4157-9af1-be8c0df9ab0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e00e739-1ed8-48b3-8478-ed643d0fa2be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0dd8eda-27d1-4173-a5a9-db95069e6f5b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "215fe811-4ff2-4532-84ce-79478b535e59");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b208662-b6f3-44b4-b1c1-6913585b9802");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9423a267-b27e-4e29-811e-bda9fd34641c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a5fc2efa-8c94-4a19-aa54-fef1dd61b93b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bae23c41-26cf-4c8e-9242-cde163417374", null, "SuperAdmin", "SUPERADMIN" },
                    { "c1adbe82-f222-45c3-8d82-0c454a224ef4", null, "Student", "STUDENT" },
                    { "cdeb8a86-2e9d-4a9a-8ce1-109ea23e4548", null, "Admin", "ADMIN" },
                    { "d3616ae7-5298-460e-ac3a-62a9671142cf", null, "Instructor", "INSTRUCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "17af0400-b581-4b23-8111-32a4a52253ed", 0, "0b39a0bb-286e-4be5-b4ff-6b1cf1385fea", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEMDU+40P1dOHwfqIi8gTm1AjAq/ZSFDwGIPu1r2eJzZqoQMjUbq9KseUrd3WvOKwEw==", null, false, "381c29f0-d65d-4e7e-a621-72cf1dc9ef81", false, "admin@mail.com" },
                    { "4a33f1ee-c52a-42b8-a40b-48b6b7da0968", 0, "8c511839-8ef6-4f84-83f1-98f9d6c9eeec", "instructor@mail.com", true, false, null, "INSTRUCTOR@MAIL.COM", "INSTRUCTOR@MAIL.COM", "AQAAAAIAAYagAAAAEDDSybqmhLJt2jFuESvOouRN+Uu+gvSbuXMsU1qX5A/xsXUU2ON6Xzv9LeRn1lkY1w==", null, false, "d4a9ca32-becb-4b72-9d27-ce57531581e2", false, "instructor@mail.com" },
                    { "6a496927-5dba-4961-9f6e-42872c6927b4", 0, "61b0d8d4-ea4d-4e1d-966d-f0cefabcc669", "student@mail.com", true, false, null, "STUDENT@MAIL.COM", "STUDENT@MAIL.COM", "AQAAAAIAAYagAAAAEK8MexWlyoNIQsdgC0GANDajkZnxXGUpWpl5OWF/cqZHUTncBy583NPHIpKGWyIdfg==", null, false, "a43fd366-4fde-46c7-b149-d27531b4f6fc", false, "student@mail.com" },
                    { "ebee14af-cd79-485a-9fc5-19a3cdba3985", 0, "d1f38012-e08f-4dff-a609-98a2fcdcd4f6", "superAdmin@mail.com", true, false, null, "SUPERADMIN@MAIL.COM", "SUPERADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEIXFPAIe0XXfrxrZOcC58vQMnukVwyjk+mmeUSo1BeJ+gw3AixBlizOcy7gZ1Vuf3w==", null, false, "a1fc3040-e3ac-4f51-8c49-75757944f814", false, "superAdmin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cdeb8a86-2e9d-4a9a-8ce1-109ea23e4548", "17af0400-b581-4b23-8111-32a4a52253ed" },
                    { "c1adbe82-f222-45c3-8d82-0c454a224ef4", "6a496927-5dba-4961-9f6e-42872c6927b4" },
                    { "d3616ae7-5298-460e-ac3a-62a9671142cf", "6a496927-5dba-4961-9f6e-42872c6927b4" },
                    { "bae23c41-26cf-4c8e-9242-cde163417374", "ebee14af-cd79-485a-9fc5-19a3cdba3985" },
                    { "cdeb8a86-2e9d-4a9a-8ce1-109ea23e4548", "ebee14af-cd79-485a-9fc5-19a3cdba3985" }
                });
        }
    }
}
