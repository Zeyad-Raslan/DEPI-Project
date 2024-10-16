using System;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineCoursesApp.DAL.Models;

public partial class OnlineCoursesContext : DbContext
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
    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<BlackList> BlackLists { get; set; }





    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //   string connectionString =
    //                      "Data Source = IUGYI\\SQLEXPRESS;" +
                         
    //                        " Initial Catalog = OnlineCourseDemo; " +
    //                        "Integrated Security = True;" +
    //                        " Encrypt = False; " +
    //                        "Trust Server Certificate=True;";
    //    optionsBuilder.UseSqlServer(connectionString);
    //}
     

   

   
}
