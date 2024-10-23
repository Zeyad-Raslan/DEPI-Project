using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineCoursesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seed_data_make_super_is_admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b3922550-90e1-491b-9c5d-c46b0636fe8f", "0f558fbb-030e-4ee7-95c9-0cb19cb1f65e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d5b16b2b-dedb-4d15-8e30-44c0166052af", "0f558fbb-030e-4ee7-95c9-0cb19cb1f65e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6e899cba-4032-40c3-91ff-ad5db60e4bae", "29f94011-5fee-4dd6-ad31-638867c15258" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bbe2865d-f65b-4601-af18-af56afdcd474", "8bd778f5-64fd-4ba8-8a81-f773017cddb1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3d8ba0b-14d8-4789-9b4d-a92e6538591a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e899cba-4032-40c3-91ff-ad5db60e4bae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3922550-90e1-491b-9c5d-c46b0636fe8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbe2865d-f65b-4601-af18-af56afdcd474");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5b16b2b-dedb-4d15-8e30-44c0166052af");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f558fbb-030e-4ee7-95c9-0cb19cb1f65e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29f94011-5fee-4dd6-ad31-638867c15258");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8bd778f5-64fd-4ba8-8a81-f773017cddb1");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "6e899cba-4032-40c3-91ff-ad5db60e4bae", null, "Admin", "ADMIN" },
                    { "b3922550-90e1-491b-9c5d-c46b0636fe8f", null, "Student", "STUDENT" },
                    { "bbe2865d-f65b-4601-af18-af56afdcd474", null, "SuperAdmin", "SUPERADMIN" },
                    { "d5b16b2b-dedb-4d15-8e30-44c0166052af", null, "Instructor", "INSTRUCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0f558fbb-030e-4ee7-95c9-0cb19cb1f65e", 0, "0280b77e-bd94-4b5e-8764-5c539b269b3d", "student@mail.com", true, false, null, "STUDENT@MAIL.COM", "STUDENT@MAIL.COM", "AQAAAAIAAYagAAAAEP7QTVhKxToj7AqZl1LLy+CcjUSx3zVfdMdKTspE4ps4z7+iDikPc6m+pDzQAw4icw==", null, false, "71e90b15-758e-4197-93f5-ea1b24989d2e", false, "student@mail.com" },
                    { "29f94011-5fee-4dd6-ad31-638867c15258", 0, "79010f06-240a-409b-bc27-6e08a3bc4aea", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEOl41OpoVIYUfbvi13gV5RFLtr2RHFGwo2hXMYPsnIrhj/LOD55XZpdy45rB/WeG7g==", null, false, "f22669f1-a06c-4312-b55b-8661bcf4eebf", false, "admin@mail.com" },
                    { "8bd778f5-64fd-4ba8-8a81-f773017cddb1", 0, "fc00712b-0adf-4f14-a587-d9a46a324bd9", "superAdmin@mail.com", true, false, null, "SUPERADMIN@MAIL.COM", "SUPERADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEEBW99qQhLhI6B+7Sq4qKLL+ks5V9DMqcsthfjiADn8VujBKnQycZPP0MFbIA+b28Q==", null, false, "1eefa214-4a5a-414e-bada-bc64d101530c", false, "superAdmin@mail.com" },
                    { "a3d8ba0b-14d8-4789-9b4d-a92e6538591a", 0, "efdea233-2392-4311-97d1-6890d94f5b4f", "instructor@mail.com", true, false, null, "INSTRUCTOR@MAIL.COM", "INSTRUCTOR@MAIL.COM", "AQAAAAIAAYagAAAAEAYPSJL4bvUNrIWKwQvj0WWWx+LK6kTQPgS06qonPxpZBh30rfFhLmB3eT9wzTlXqw==", null, false, "cc2fbbb7-82d2-43d0-b2a6-bf759be50fce", false, "instructor@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b3922550-90e1-491b-9c5d-c46b0636fe8f", "0f558fbb-030e-4ee7-95c9-0cb19cb1f65e" },
                    { "d5b16b2b-dedb-4d15-8e30-44c0166052af", "0f558fbb-030e-4ee7-95c9-0cb19cb1f65e" },
                    { "6e899cba-4032-40c3-91ff-ad5db60e4bae", "29f94011-5fee-4dd6-ad31-638867c15258" },
                    { "bbe2865d-f65b-4601-af18-af56afdcd474", "8bd778f5-64fd-4ba8-8a81-f773017cddb1" }
                });
        }
    }
}
