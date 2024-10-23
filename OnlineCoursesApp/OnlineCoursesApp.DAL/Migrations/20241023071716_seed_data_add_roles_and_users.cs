using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineCoursesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seed_data_add_roles_and_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fb263fb1-99e8-49aa-be62-4f255e14afa3", "39edadb3-4712-46e1-8e2e-47b3fd3ff2a9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "00cddc5d-13ef-4ca0-828c-cb1d7ddb8e36", "e86e991a-ca18-43b9-9988-d8ee5ecd8dbb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00cddc5d-13ef-4ca0-828c-cb1d7ddb8e36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb263fb1-99e8-49aa-be62-4f255e14afa3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39edadb3-4712-46e1-8e2e-47b3fd3ff2a9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e86e991a-ca18-43b9-9988-d8ee5ecd8dbb");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "00cddc5d-13ef-4ca0-828c-cb1d7ddb8e36", null, "Admin", "ADMIN" },
                    { "fb263fb1-99e8-49aa-be62-4f255e14afa3", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "39edadb3-4712-46e1-8e2e-47b3fd3ff2a9", 0, "5be0e271-3b69-4314-8809-24d1bd0c0dfa", "mm@mm.mm", true, false, null, "MM@MM.MM", "MM@MM.MM", "AQAAAAIAAYagAAAAEFi1ioIoa6pfQQRycdxZknYtIIBi7Lx3jRGhxo67xjbFv9x7w0GTrnhl2ObcC/x3aA==", null, false, "d7d88063-c03e-4adf-86f9-6e4bb547c1fe", false, "mm@mm.mm" },
                    { "e86e991a-ca18-43b9-9988-d8ee5ecd8dbb", 0, "6873d264-fc67-414a-a2cc-3ae99258056b", "aa@aa.aa", true, false, null, "AA@AA.AA", "AA@AA.AA", "AQAAAAIAAYagAAAAEDBEpM6HRKKe+/yEm4XB93SUk3xfWJ84bcyisngjMQAJKIfit3f/6G3xBc6EalRKCg==", null, false, "901fd35e-25a6-434a-8f52-04d3b983cb0e", false, "aa@aa.aa" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fb263fb1-99e8-49aa-be62-4f255e14afa3", "39edadb3-4712-46e1-8e2e-47b3fd3ff2a9" },
                    { "00cddc5d-13ef-4ca0-828c-cb1d7ddb8e36", "e86e991a-ca18-43b9-9988-d8ee5ecd8dbb" }
                });
        }
    }
}
