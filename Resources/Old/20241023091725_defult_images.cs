using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineCoursesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class defult_images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3cfa0020-c5a6-47ee-a7d7-aa4aceffa119", "21f23f32-9567-4cdd-9c60-5e8d7e6a67d2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "37056535-2534-4634-91d4-cc506e186b2b", "26984fe9-cb44-4bd9-8013-55e341422fd9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "38f55e88-d8be-4b66-b55f-6ee71fa81f2d", "3546a635-ba57-4ae9-b90d-e7635cfbc66c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "37056535-2534-4634-91d4-cc506e186b2b", "b8b08092-20ce-4250-83cf-ab9b1d219f27" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e81907ac-1310-42d4-9870-45d2d8bf81e1", "b8b08092-20ce-4250-83cf-ab9b1d219f27" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37056535-2534-4634-91d4-cc506e186b2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38f55e88-d8be-4b66-b55f-6ee71fa81f2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cfa0020-c5a6-47ee-a7d7-aa4aceffa119");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e81907ac-1310-42d4-9870-45d2d8bf81e1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21f23f32-9567-4cdd-9c60-5e8d7e6a67d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26984fe9-cb44-4bd9-8013-55e341422fd9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3546a635-ba57-4ae9-b90d-e7635cfbc66c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8b08092-20ce-4250-83cf-ab9b1d219f27");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a9dab90-e593-49c9-bf32-9b7b0b4e7453", null, "Student", "STUDENT" },
                    { "6a9b2899-b073-4c38-8e59-0b4d619cfefd", null, "Instructor", "INSTRUCTOR" },
                    { "771c7d90-01cb-48d8-91b2-05ad54e2d47a", null, "Admin", "ADMIN" },
                    { "da6a45b2-029e-4f68-9893-baafeed405a5", null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "17de889d-7636-4980-b4ff-44a336a37913", 0, "6499442b-387a-471e-89e0-9499ba6896d7", "superAdmin@mail.com", true, false, null, "SUPERADMIN@MAIL.COM", "SUPERADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEIg0PsJ2z+33lk7Dp8+bDQf8JW63DjPvL0LHmh7ZmroGmr82RbRpajFQAitSElCGQg==", null, false, "aa2a7cc0-959e-4363-8db5-1536636393f0", false, "superAdmin@mail.com" },
                    { "408fec77-c59b-4d59-a330-35bffb0c7276", 0, "ea3ff00a-cbf9-4314-88e2-1d890f6e91b2", "student@mail.com", true, false, null, "STUDENT@MAIL.COM", "STUDENT@MAIL.COM", "AQAAAAIAAYagAAAAEMHh2tP2z0MztH88YUxF8qs1to0fpv9nuIX5vpMg27sjWTCazhuDEmIGhGVUnLi+MQ==", null, false, "45339c2e-5a86-476a-ac65-331dd10eeeb7", false, "student@mail.com" },
                    { "8cb40f13-752c-4ce2-bbc8-08285375d385", 0, "ba8c43c3-7c28-4bd9-8212-b2de64fe65f7", "instructor@mail.com", true, false, null, "INSTRUCTOR@MAIL.COM", "INSTRUCTOR@MAIL.COM", "AQAAAAIAAYagAAAAEBT5J2Ky8abpXUMC8a71mfl7EEVd9tMUCRt5/sF2/70KgWsZtOGg+lRNdX/JG5ux8A==", null, false, "4d3ee197-cb90-4406-9630-ef87857a1926", false, "instructor@mail.com" },
                    { "e461ec30-65cb-40f6-8889-9f9432fd6c9b", 0, "2793e790-8ce1-4f1a-b2a8-9a0e9dc521a6", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEDYJ2qGhkSCbw/ujftUSXWnOlBBf+Uu1goFLFxJU8T5dase/9jIPThhoEE4RC8weQw==", null, false, "2874b3f3-cb22-452a-a35d-c8c55a93ea59", false, "admin@mail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: -1,
                column: "IdentityUserID",
                value: "8cb40f13-752c-4ce2-bbc8-08285375d385");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: -1,
                column: "IdentityUserID",
                value: "408fec77-c59b-4d59-a330-35bffb0c7276");

            migrationBuilder.UpdateData(
                table: "WebAdmins",
                keyColumn: "ID",
                keyValue: -2,
                column: "IdentityUserID",
                value: "e461ec30-65cb-40f6-8889-9f9432fd6c9b");

            migrationBuilder.UpdateData(
                table: "WebAdmins",
                keyColumn: "ID",
                keyValue: -1,
                column: "IdentityUserID",
                value: "17de889d-7636-4980-b4ff-44a336a37913");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "771c7d90-01cb-48d8-91b2-05ad54e2d47a", "17de889d-7636-4980-b4ff-44a336a37913" },
                    { "da6a45b2-029e-4f68-9893-baafeed405a5", "17de889d-7636-4980-b4ff-44a336a37913" },
                    { "5a9dab90-e593-49c9-bf32-9b7b0b4e7453", "408fec77-c59b-4d59-a330-35bffb0c7276" },
                    { "6a9b2899-b073-4c38-8e59-0b4d619cfefd", "8cb40f13-752c-4ce2-bbc8-08285375d385" },
                    { "771c7d90-01cb-48d8-91b2-05ad54e2d47a", "e461ec30-65cb-40f6-8889-9f9432fd6c9b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "771c7d90-01cb-48d8-91b2-05ad54e2d47a", "17de889d-7636-4980-b4ff-44a336a37913" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "da6a45b2-029e-4f68-9893-baafeed405a5", "17de889d-7636-4980-b4ff-44a336a37913" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5a9dab90-e593-49c9-bf32-9b7b0b4e7453", "408fec77-c59b-4d59-a330-35bffb0c7276" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6a9b2899-b073-4c38-8e59-0b4d619cfefd", "8cb40f13-752c-4ce2-bbc8-08285375d385" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "771c7d90-01cb-48d8-91b2-05ad54e2d47a", "e461ec30-65cb-40f6-8889-9f9432fd6c9b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a9dab90-e593-49c9-bf32-9b7b0b4e7453");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a9b2899-b073-4c38-8e59-0b4d619cfefd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "771c7d90-01cb-48d8-91b2-05ad54e2d47a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da6a45b2-029e-4f68-9893-baafeed405a5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "17de889d-7636-4980-b4ff-44a336a37913");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408fec77-c59b-4d59-a330-35bffb0c7276");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8cb40f13-752c-4ce2-bbc8-08285375d385");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e461ec30-65cb-40f6-8889-9f9432fd6c9b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37056535-2534-4634-91d4-cc506e186b2b", null, "Admin", "ADMIN" },
                    { "38f55e88-d8be-4b66-b55f-6ee71fa81f2d", null, "Student", "STUDENT" },
                    { "3cfa0020-c5a6-47ee-a7d7-aa4aceffa119", null, "Instructor", "INSTRUCTOR" },
                    { "e81907ac-1310-42d4-9870-45d2d8bf81e1", null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "21f23f32-9567-4cdd-9c60-5e8d7e6a67d2", 0, "3373316c-f095-4fb7-8ffc-2390680d673c", "instructor@mail.com", true, false, null, "INSTRUCTOR@MAIL.COM", "INSTRUCTOR@MAIL.COM", "AQAAAAIAAYagAAAAEJSjEMJJezcFjmGVE+jvufk3pQxw5a4Z5nBJeHFNgQGi6BfjG7oxBs1fdl0uVDCLKg==", null, false, "271ba080-7a62-4fab-b6a5-54615998996a", false, "instructor@mail.com" },
                    { "26984fe9-cb44-4bd9-8013-55e341422fd9", 0, "2c82abe6-4089-405b-b649-249e45d9d05c", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEBYgMswla7olzzIzR8JSvJcYaB8mBRlxzanI3iOU5xs5Md9+X6NiPgkqOIBkiiBM1A==", null, false, "4e4dc85d-2fb8-4fb1-8d5a-28f624e7a75f", false, "admin@mail.com" },
                    { "3546a635-ba57-4ae9-b90d-e7635cfbc66c", 0, "edf7aa95-b537-43eb-9712-fbfc826fd4d4", "student@mail.com", true, false, null, "STUDENT@MAIL.COM", "STUDENT@MAIL.COM", "AQAAAAIAAYagAAAAEFYjHOQY3vdolL6usN9wl+WEHWmqTbnztCc4ZDvQPUJcbMo8Uy9ht5Cdug5Bev+N5g==", null, false, "8a70f843-fdcd-47d1-9f8d-408db1c2c9db", false, "student@mail.com" },
                    { "b8b08092-20ce-4250-83cf-ab9b1d219f27", 0, "9b4884fe-58a2-4b3c-b681-154566fc5e7c", "superAdmin@mail.com", true, false, null, "SUPERADMIN@MAIL.COM", "SUPERADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEHJwrPZv9Awv1ayuIcW8guJRvpqI/NyS/WnQWTC7ogE9raO3OO5S3mHCITJ0YS+DRA==", null, false, "ddeacf70-a45e-428f-a2d6-3492986993af", false, "superAdmin@mail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: -1,
                column: "IdentityUserID",
                value: "21f23f32-9567-4cdd-9c60-5e8d7e6a67d2");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: -1,
                column: "IdentityUserID",
                value: "3546a635-ba57-4ae9-b90d-e7635cfbc66c");

            migrationBuilder.UpdateData(
                table: "WebAdmins",
                keyColumn: "ID",
                keyValue: -2,
                column: "IdentityUserID",
                value: "26984fe9-cb44-4bd9-8013-55e341422fd9");

            migrationBuilder.UpdateData(
                table: "WebAdmins",
                keyColumn: "ID",
                keyValue: -1,
                column: "IdentityUserID",
                value: "b8b08092-20ce-4250-83cf-ab9b1d219f27");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3cfa0020-c5a6-47ee-a7d7-aa4aceffa119", "21f23f32-9567-4cdd-9c60-5e8d7e6a67d2" },
                    { "37056535-2534-4634-91d4-cc506e186b2b", "26984fe9-cb44-4bd9-8013-55e341422fd9" },
                    { "38f55e88-d8be-4b66-b55f-6ee71fa81f2d", "3546a635-ba57-4ae9-b90d-e7635cfbc66c" },
                    { "37056535-2534-4634-91d4-cc506e186b2b", "b8b08092-20ce-4250-83cf-ab9b1d219f27" },
                    { "e81907ac-1310-42d4-9870-45d2d8bf81e1", "b8b08092-20ce-4250-83cf-ab9b1d219f27" }
                });
        }
    }
}
