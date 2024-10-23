using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineCoursesApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class set_default_imges_fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6bc12c01-c25f-4c0e-a972-07acb1a2205c", "1b1b18f7-2a8b-4297-9aed-7dd76f26b09b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "710cc79b-7beb-452a-b970-6bd62c0f5851", "8a5301db-3b1b-4a99-8fd1-7e03b00ec621" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "19aa2745-b7bc-4bf4-abd6-6a342d3a90da", "96daf944-376d-4cd5-b092-2e0740e959f2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4181d5b0-d91e-4f6b-8b4f-9086643e6b4e", "9ecef325-35c9-43e3-aea6-396981c2897b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6bc12c01-c25f-4c0e-a972-07acb1a2205c", "9ecef325-35c9-43e3-aea6-396981c2897b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19aa2745-b7bc-4bf4-abd6-6a342d3a90da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4181d5b0-d91e-4f6b-8b4f-9086643e6b4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bc12c01-c25f-4c0e-a972-07acb1a2205c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "710cc79b-7beb-452a-b970-6bd62c0f5851");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b1b18f7-2a8b-4297-9aed-7dd76f26b09b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a5301db-3b1b-4a99-8fd1-7e03b00ec621");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "96daf944-376d-4cd5-b092-2e0740e959f2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ecef325-35c9-43e3-aea6-396981c2897b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "122c765f-c4bb-4049-b280-e20200af947a", null, "Instructor", "INSTRUCTOR" },
                    { "2358588c-838d-44c2-b51f-00ade455e336", null, "Student", "STUDENT" },
                    { "5e1471b4-4f1e-49c3-bb82-56dbac59d736", null, "SuperAdmin", "SUPERADMIN" },
                    { "fc5274d1-9c73-426d-8fe6-a3a20a07ef9d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "21e1a67d-371d-4f9c-9ecd-269e6ae32681", 0, "3fb5b99c-9051-401b-b40a-54a4999e44f9", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEIjsHki10l3ryCd0exjSS4XHNkfllN08DitKs3q8nFpw+OJ10U1+1LR6s5rs0NrHKQ==", null, false, "d91a9223-87b3-4153-be5a-1e68a1c59100", false, "admin@mail.com" },
                    { "95d4c99b-0967-454b-90fc-176dc0ca4947", 0, "43369278-bd23-40ed-9918-55c7ec88a813", "student@mail.com", true, false, null, "STUDENT@MAIL.COM", "STUDENT@MAIL.COM", "AQAAAAIAAYagAAAAENPPAX/cr7iWqN+jsd8/Ii9EpEbfvUESZaDk1oqxO5vSzreZ+Gapm6Z13dPMJ2IVMA==", null, false, "ec41c437-d570-41a0-8f2e-9a715844bcde", false, "student@mail.com" },
                    { "a5575aa4-79e1-489c-96a9-730ab15bb92f", 0, "ba629fff-8d44-408a-923c-a0d06f1f4701", "instructor@mail.com", true, false, null, "INSTRUCTOR@MAIL.COM", "INSTRUCTOR@MAIL.COM", "AQAAAAIAAYagAAAAEB8NnmmNEI7XpctyluKo2Nky3gHrPuf+CukRdvq2d1iOdNmqNQrxzijhQtFQG8pMjg==", null, false, "98b7934d-80a7-4269-8d53-f8e0282f5afd", false, "instructor@mail.com" },
                    { "d2251667-84de-44a2-82d8-275fd697fb5d", 0, "4c366c8a-6cbe-4059-bfe9-98eafb8ee3db", "superAdmin@mail.com", true, false, null, "SUPERADMIN@MAIL.COM", "SUPERADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEISPbsQP8k1IVR6at6KxFICfPZpsoRJ9FjIaIS4WarHXnfbMRNb3dP+sUjRpXSlO5w==", null, false, "5f3341e0-6066-4651-94bd-31ba0a3e5299", false, "superAdmin@mail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: -1,
                columns: new[] { "IdentityUserID", "Image" },
                values: new object[] { "a5575aa4-79e1-489c-96a9-730ab15bb92f", "/image/Instructor/default.png" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: -1,
                columns: new[] { "IdentityUserID", "Image" },
                values: new object[] { "95d4c99b-0967-454b-90fc-176dc0ca4947", "/image/Student/default.png" });

            migrationBuilder.UpdateData(
                table: "WebAdmins",
                keyColumn: "ID",
                keyValue: -2,
                column: "IdentityUserID",
                value: "21e1a67d-371d-4f9c-9ecd-269e6ae32681");

            migrationBuilder.UpdateData(
                table: "WebAdmins",
                keyColumn: "ID",
                keyValue: -1,
                column: "IdentityUserID",
                value: "d2251667-84de-44a2-82d8-275fd697fb5d");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fc5274d1-9c73-426d-8fe6-a3a20a07ef9d", "21e1a67d-371d-4f9c-9ecd-269e6ae32681" },
                    { "2358588c-838d-44c2-b51f-00ade455e336", "95d4c99b-0967-454b-90fc-176dc0ca4947" },
                    { "122c765f-c4bb-4049-b280-e20200af947a", "a5575aa4-79e1-489c-96a9-730ab15bb92f" },
                    { "5e1471b4-4f1e-49c3-bb82-56dbac59d736", "d2251667-84de-44a2-82d8-275fd697fb5d" },
                    { "fc5274d1-9c73-426d-8fe6-a3a20a07ef9d", "d2251667-84de-44a2-82d8-275fd697fb5d" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc5274d1-9c73-426d-8fe6-a3a20a07ef9d", "21e1a67d-371d-4f9c-9ecd-269e6ae32681" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2358588c-838d-44c2-b51f-00ade455e336", "95d4c99b-0967-454b-90fc-176dc0ca4947" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "122c765f-c4bb-4049-b280-e20200af947a", "a5575aa4-79e1-489c-96a9-730ab15bb92f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5e1471b4-4f1e-49c3-bb82-56dbac59d736", "d2251667-84de-44a2-82d8-275fd697fb5d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc5274d1-9c73-426d-8fe6-a3a20a07ef9d", "d2251667-84de-44a2-82d8-275fd697fb5d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "122c765f-c4bb-4049-b280-e20200af947a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2358588c-838d-44c2-b51f-00ade455e336");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e1471b4-4f1e-49c3-bb82-56dbac59d736");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc5274d1-9c73-426d-8fe6-a3a20a07ef9d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21e1a67d-371d-4f9c-9ecd-269e6ae32681");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95d4c99b-0967-454b-90fc-176dc0ca4947");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a5575aa4-79e1-489c-96a9-730ab15bb92f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2251667-84de-44a2-82d8-275fd697fb5d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19aa2745-b7bc-4bf4-abd6-6a342d3a90da", null, "Student", "STUDENT" },
                    { "4181d5b0-d91e-4f6b-8b4f-9086643e6b4e", null, "SuperAdmin", "SUPERADMIN" },
                    { "6bc12c01-c25f-4c0e-a972-07acb1a2205c", null, "Admin", "ADMIN" },
                    { "710cc79b-7beb-452a-b970-6bd62c0f5851", null, "Instructor", "INSTRUCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1b1b18f7-2a8b-4297-9aed-7dd76f26b09b", 0, "d57a0692-6b7b-4922-bb19-dce0db2f68b4", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEDBpFrNh69V1hX6wS+2mKZAgN0+RW7lce8I4nY5CbEPv3MnVIMylAY/HaOXTy+hzPg==", null, false, "9c3a328a-7b5d-4f8b-ac80-42ef56e717d8", false, "admin@mail.com" },
                    { "8a5301db-3b1b-4a99-8fd1-7e03b00ec621", 0, "22fe7583-091a-4b58-b9d6-637f9e233dd1", "instructor@mail.com", true, false, null, "INSTRUCTOR@MAIL.COM", "INSTRUCTOR@MAIL.COM", "AQAAAAIAAYagAAAAEAzhW2xYV3moBqQcDfMA6Gq1BFmAF7O35Xexm35pOjB8BMG4h6Lk+MI7wVLkXEbhug==", null, false, "7fb5b3fb-3c2e-4321-bb60-1a614556a74c", false, "instructor@mail.com" },
                    { "96daf944-376d-4cd5-b092-2e0740e959f2", 0, "8e16fab1-a644-406e-8e7b-82c5aefab18b", "student@mail.com", true, false, null, "STUDENT@MAIL.COM", "STUDENT@MAIL.COM", "AQAAAAIAAYagAAAAEO1fmbR7ny8GS4kGJZnaIkQKaz5+0r2POznVJutoaiiFDgWT+8Zjj2W6Rh3HgQPR0Q==", null, false, "73f5da9c-86ff-4b8c-929b-0040c5ea0e4d", false, "student@mail.com" },
                    { "9ecef325-35c9-43e3-aea6-396981c2897b", 0, "4e03e5dd-e6e6-408f-858a-ace6813d97c2", "superAdmin@mail.com", true, false, null, "SUPERADMIN@MAIL.COM", "SUPERADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEK3qg1ySMNMBXrPTCsv/8S5ayKsvxUytIaaOD4zYeN0ZdE2xublK2g1pjcrPRR0h8Q==", null, false, "3c0c0a8c-bd55-46d3-94ea-d5c5a1bb03c5", false, "superAdmin@mail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Instructors",
                keyColumn: "InstructorId",
                keyValue: -1,
                columns: new[] { "IdentityUserID", "Image" },
                values: new object[] { "8a5301db-3b1b-4a99-8fd1-7e03b00ec621", "F:\\CSE_56\\DEPI\\DEPI_Project\\Project_Source_Code\\DEPI-Project\\OnlineCoursesApp\\OnlineCoursesApp\\wwwroot\\image\\default_profil _mage5.png" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: -1,
                columns: new[] { "IdentityUserID", "Image" },
                values: new object[] { "96daf944-376d-4cd5-b092-2e0740e959f2", "F:\\CSE_56\\DEPI\\DEPI_Project\\Project_Source_Code\\DEPI-Project\\OnlineCoursesApp\\OnlineCoursesApp\\wwwroot\\image\\Student\\default.png" });

            migrationBuilder.UpdateData(
                table: "WebAdmins",
                keyColumn: "ID",
                keyValue: -2,
                column: "IdentityUserID",
                value: "1b1b18f7-2a8b-4297-9aed-7dd76f26b09b");

            migrationBuilder.UpdateData(
                table: "WebAdmins",
                keyColumn: "ID",
                keyValue: -1,
                column: "IdentityUserID",
                value: "9ecef325-35c9-43e3-aea6-396981c2897b");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6bc12c01-c25f-4c0e-a972-07acb1a2205c", "1b1b18f7-2a8b-4297-9aed-7dd76f26b09b" },
                    { "710cc79b-7beb-452a-b970-6bd62c0f5851", "8a5301db-3b1b-4a99-8fd1-7e03b00ec621" },
                    { "19aa2745-b7bc-4bf4-abd6-6a342d3a90da", "96daf944-376d-4cd5-b092-2e0740e959f2" },
                    { "4181d5b0-d91e-4f6b-8b4f-9086643e6b4e", "9ecef325-35c9-43e3-aea6-396981c2897b" },
                    { "6bc12c01-c25f-4c0e-a972-07acb1a2205c", "9ecef325-35c9-43e3-aea6-396981c2897b" }
                });
        }
    }
}
