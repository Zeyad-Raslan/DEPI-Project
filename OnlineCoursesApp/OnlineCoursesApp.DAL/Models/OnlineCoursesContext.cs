using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineCoursesApp.DAL.Seeds;

namespace OnlineCoursesApp.DAL.Models;

public partial class OnlineCoursesContext :IdentityDbContext<IdentityUser>
{
   public OnlineCoursesContext(DbContextOptions<OnlineCoursesContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Instructor> Instructors { get; set; }
    public virtual DbSet<StudentProgress> StudentProgresses { get; set; }
    public virtual DbSet<Section> Sections { get; set; }
    public virtual DbSet<WebAdmin> WebAdmins { get; set; }
    public virtual DbSet<BlackList> BlackLists { get; set; }





    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    string connectionString =
    //         //"Data Source = IUGYI\\SQLEXPRESS;" +
    //                         "Data Source = IUGYI\\SQLEXPRESS;" +
    //                         " Initial Catalog = OnlineCourseDemo02; " +
    //                         "Integrated Security = True;" +
    //                         " Encrypt = False; " +
    //                         "Trust Server Certificate=True;";
    //    optionsBuilder.UseSqlServer(connectionString);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Loop through all foreign keys in the model
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // Loop through all foreign key relationships
            foreach (var foreignKey in entityType.GetForeignKeys())
            {
                // Set the delete behavior to Restrict for each FK
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
        modelBuilder.Entity<StudentProgress>()
            .HasOne(sp => sp.Section)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StudentProgress>()
           .HasOne(sp => sp.Student)
           .WithMany()
           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StudentProgress>()
           .HasOne(sp => sp.Course)
           .WithMany()
           .OnDelete(DeleteBehavior.Cascade);
    

    

        // Use seed method here
        SeedUsersRoles seedUsersRoles = new SeedUsersRoles();
        modelBuilder.Entity<IdentityRole>().HasData(seedUsersRoles.Roles);
        modelBuilder.Entity<IdentityUser>().HasData(seedUsersRoles.Users);
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(seedUsersRoles.UserRoles);

        // Add Account of Super Admin
        WebAdmin superWebAdmin = new WebAdmin()
        {ID = -1 , // for seeding
            Name = "Super Admin",
            Email = seedUsersRoles.Users.ElementAt(0).Email,
            IdentityUserID = seedUsersRoles.Users.ElementAt(0).Id,
           //IdentityUser = seedUsersRoles.Users.ElementAt(0)

        };
        modelBuilder.Entity<WebAdmin>().HasData(superWebAdmin);
        // add admin
        WebAdmin normalWebAdmin = new WebAdmin()
        {
            ID = -2 , // for seeding
            Name = "Normal Admin",
            Email = seedUsersRoles.Users.ElementAt(1).Email,
            IdentityUserID = seedUsersRoles.Users.ElementAt(1).Id,
            //IdentityUser = seedUsersRoles.Users.ElementAt(1)

        };
        modelBuilder.Entity<WebAdmin>().HasData(normalWebAdmin);
        // add student
        Student student = new Student()
        {
            StudentId = -1, // for seeding
            Name = "Student Seed",
            Email = seedUsersRoles.Users.ElementAt(2).Email,
            IdentityUserID = seedUsersRoles.Users.ElementAt(2).Id,
            //IdentityUser = seedUsersRoles.Users.ElementAt(2)

        };
        modelBuilder.Entity<Student>().HasData(student);
        // add Instructor
        Instructor instructor = new Instructor()
        {
            InstructorId = -1, // for seeding
            Name = "instructor Seed",
            Email = seedUsersRoles.Users.ElementAt(3).Email,
            IdentityUserID = seedUsersRoles.Users.ElementAt(3).Id,
            //IdentityUser = seedUsersRoles.Users.ElementAt(3)

        };
        modelBuilder.Entity<Instructor>().HasData(instructor);


    }



}
