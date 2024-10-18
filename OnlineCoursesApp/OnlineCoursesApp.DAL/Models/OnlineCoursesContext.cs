using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OnlineCoursesApp.DAL.Models;

public partial class OnlineCoursesContext :IdentityDbContext<IdentityUser>
{
    public OnlineCoursesContext()
    {
    }

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





    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString =
             //"Data Source = IUGYI\\SQLEXPRESS;" +
                             "Data Source = IUGYI\\SQLEXPRESS;" +
                             " Initial Catalog = OnlineCourseDemo02; " +
                             "Integrated Security = True;" +
                             " Encrypt = False; " +
                             "Trust Server Certificate=True;";
        optionsBuilder.UseSqlServer(connectionString);
    }

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
    }





}
