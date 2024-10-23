using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OnlineCoursesApp.DAL.Seeds
{
    public class SeedUsersRoles
    {
        private readonly List<IdentityRole> _roles;
        private readonly List<IdentityUser> _users;
        private readonly List<IdentityUserRole<string>> _userRoles;
        public SeedUsersRoles()
        {
            _roles = GetRoles();
            _users = GetUsers();
            _userRoles = GetUserRoles(_users, _roles);
        }

        public List<IdentityRole> Roles { get { return _roles; } }
        public List<IdentityUser> Users { get { return _users; } }
        public List<IdentityUserRole<string>> UserRoles { get { return _userRoles; } }

        private List<IdentityRole> GetRoles()
        {

            // Seed Roles

            var SuperAdminRole = new IdentityRole("SuperAdmin");
            SuperAdminRole.NormalizedName = SuperAdminRole.Name!.ToUpper();

            var adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = adminRole.Name!.ToUpper();

            var studentRole = new IdentityRole("Student");
            studentRole.NormalizedName = studentRole.Name!.ToUpper();

            var instructorRole = new IdentityRole("Instructor");
            instructorRole.NormalizedName = instructorRole.Name!.ToUpper();

            List<IdentityRole> roles = new List<IdentityRole>() {
                                SuperAdminRole,
                                adminRole,
                                studentRole,
                                instructorRole
            };

            return roles;
        }

        private List<IdentityUser> GetUsers()
        {

            //string pwd = "superAdmin";
            var passwordHasher = new PasswordHasher<IdentityUser>();

            // Seed Users
            // Super Admin 
            var superAdminUser = new IdentityUser
            {
                UserName = "superAdmin@mail.com",
                Email = "superAdmin@mail.com",
                EmailConfirmed = true,
            };
            superAdminUser.NormalizedUserName = superAdminUser.UserName.ToUpper();
            superAdminUser.NormalizedEmail = superAdminUser.Email.ToUpper();
            superAdminUser.PasswordHash = passwordHasher.
                HashPassword(superAdminUser, "superAdmin");

            var adminUser = new IdentityUser
            {
                UserName = "admin@mail.com",
                Email = "admin@mail.com",
                EmailConfirmed = true,
            };
            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = passwordHasher.
                HashPassword(adminUser, "admin");

            var studentUser = new IdentityUser
            {
                UserName = "student@mail.com",
                Email = "student@mail.com",
                EmailConfirmed = true,
            };
            studentUser.NormalizedUserName = studentUser.UserName.ToUpper();
            studentUser.NormalizedEmail = studentUser.Email.ToUpper();
            studentUser.PasswordHash = passwordHasher.
                HashPassword(studentUser, "student");

            var instructorUser = new IdentityUser
            {
                UserName = "instructor@mail.com",
                Email = "instructor@mail.com",
                EmailConfirmed = true,
            };
            instructorUser.NormalizedUserName = instructorUser.UserName.ToUpper();
            instructorUser.NormalizedEmail = instructorUser.Email.ToUpper();
            instructorUser.PasswordHash = passwordHasher.
                HashPassword(instructorUser, "instructor");

            List <IdentityUser> users = new List<IdentityUser>() {
                        superAdminUser,
                        adminUser,
                        studentUser,
                        instructorUser

            };

            return users;
        }

        private List<IdentityUserRole<string>> GetUserRoles(List<IdentityUser> users, List<IdentityRole> roles)
        {
            // Seed UserRoles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "SuperAdmin").Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[2].Id,
                RoleId = roles.First(q => q.Name == "Student").Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[3].Id,
                RoleId = roles.First(q => q.Name == "Instructor").Id
            });

            return userRoles;
        }
    }

}

