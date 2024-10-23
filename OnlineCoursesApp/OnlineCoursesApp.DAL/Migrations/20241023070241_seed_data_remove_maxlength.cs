using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineCoursesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seed_data_remove_maxlength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c6eb5f2f-e74a-4414-b95e-78c82729405a", "870ffe84-44ff-4d75-bb3b-5b153207e67a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "332e353f-de1a-458f-887a-3b74db398122", "e9da5ce5-649c-4d60-927c-cfc02c8defc1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "332e353f-de1a-458f-887a-3b74db398122");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6eb5f2f-e74a-4414-b95e-78c82729405a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "870ffe84-44ff-4d75-bb3b-5b153207e67a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e9da5ce5-649c-4d60-927c-cfc02c8defc1");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "332e353f-de1a-458f-887a-3b74db398122", null, "Member", "MEMBER" },
                    { "c6eb5f2f-e74a-4414-b95e-78c82729405a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "870ffe84-44ff-4d75-bb3b-5b153207e67a", 0, "ac0e39fa-da0b-4d05-a6d5-cbf27ce418b0", "aa@aa.aa", true, false, null, "AA@AA.AA", "AA@AA.AA", "AQAAAAIAAYagAAAAEN98nItpdObKGoHA0FuWL15h2swRbkUPGRw63bbUzh+EyCr6/CZSuiWH+aCQn3IgMw==", null, false, "57ade827-38e6-4290-811a-eb8289e8d118", false, "aa@aa.aa" },
                    { "e9da5ce5-649c-4d60-927c-cfc02c8defc1", 0, "9724e72d-2586-4feb-9533-9a0eea2f49d3", "mm@mm.mm", true, false, null, "MM@MM.MM", "MM@MM.MM", "AQAAAAIAAYagAAAAEMgvJXBIPj0Tp7/3jhbHMWpzTh3+kYye5egWItfob9D9zg08dwuA8RGaHZgpMIOPYA==", null, false, "636171ea-6ae7-4239-8445-8004ed99901b", false, "mm@mm.mm" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c6eb5f2f-e74a-4414-b95e-78c82729405a", "870ffe84-44ff-4d75-bb3b-5b153207e67a" },
                    { "332e353f-de1a-458f-887a-3b74db398122", "e9da5ce5-649c-4d60-927c-cfc02c8defc1" }
                });
        }
    }
}
