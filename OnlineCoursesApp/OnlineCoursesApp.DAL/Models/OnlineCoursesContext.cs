using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.DAL.Models
{
    public class OnlineCoursesDbContext : DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<StudentProgress> StudentProgresses { get; set; }
        public DbSet<Enroll> Enrolls { get; set; }
        public DbSet<Tech> Techs { get; set; }

        public OnlineCoursesDbContext(DbContextOptions<OnlineCoursesDbContext> options): base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // Many-to-Many relationship between Student and Course (Enroll)
            modelBuilder.Entity<Enroll>()
                .HasKey(e => new { e.StudentID, e.CourseID });
            modelBuilder.Entity<Enroll>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentID)
                .OnDelete(DeleteBehavior.NoAction);  // No Action on Delete for Student
            modelBuilder.Entity<Enroll>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseID)
                .OnDelete(DeleteBehavior.NoAction);  // No Action on Delete for Course

            // Many-to-Many relationship between Instructor and Course (Tech)
            modelBuilder.Entity<Tech>()
                .HasKey(t => new { t.InstructorID, t.CourseID });
            modelBuilder.Entity<Tech>()
                .HasOne(t => t.Instructor)
                .WithMany(i => i.Techs)
                .HasForeignKey(t => t.InstructorID)
                .OnDelete(DeleteBehavior.NoAction);  // No Action on Delete for Instructor
            modelBuilder.Entity<Tech>()
                .HasOne(t => t.Course)
                .WithMany(c => c.Techs)
                .HasForeignKey(t => t.CourseID)
                .OnDelete(DeleteBehavior.NoAction);  // No Action on Delete for Course

            // One-to-Many relationship between Section and Course
            modelBuilder.Entity<Section>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Sections)
                .HasForeignKey(s => s.CourseID)
                .OnDelete(DeleteBehavior.NoAction);  // No Action on Delete for Course in Section

            // One-to-Many relationships for StudentProgress
            modelBuilder.Entity<StudentProgress>()
                .HasOne(sp => sp.Course)
                .WithMany(c => c.StudentProgresses)
                .HasForeignKey(sp => sp.CourseID)
                .OnDelete(DeleteBehavior.NoAction);  // No Action on Delete for Course in StudentProgress
            modelBuilder.Entity<StudentProgress>()
                .HasOne(sp => sp.Student)
                .WithMany(s => s.StudentProgresses)
                .HasForeignKey(sp => sp.StudentID)
                .OnDelete(DeleteBehavior.NoAction);  // No Action on Delete for Student in StudentProgress
            modelBuilder.Entity<StudentProgress>()
                .HasOne(sp => sp.Section)
                .WithMany(s => s.StudentProgresses)
                .HasForeignKey(sp => sp.SectionID)
                .OnDelete(DeleteBehavior.NoAction);  // No Action on Delete for Section in StudentProgress




            // DefultValue

            // modelBuilder.Entity<Course>()
            //     .Property(c => c.Status)
            //     .HasDefaultValue(CourseStatus.UnderReview);
            //     base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<StudentProgress>()
            //     .Property(sp => sp.IsCompleted)
            //     .HasDefaultValue(false);

            // // Unique 

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();

            modelBuilder.Entity<Instructor>()
                .HasIndex(i => i.Email)
                .IsUnique();



        }

    }
}
