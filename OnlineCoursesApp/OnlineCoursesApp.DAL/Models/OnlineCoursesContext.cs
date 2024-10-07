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

    public virtual DbSet<Enroll> Enrolls { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=OnlineCoursesDB;Trusted_Connection=True;Integrated Security = SSPI; TrustServerCertificate = True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D71A75FE343BA");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Status).HasDefaultValue(0);
            entity.Property(e => e.Type).HasMaxLength(100);
        });

        modelBuilder.Entity<Enroll>(entity =>
        {
            entity.HasKey(e => new { e.CourseId, e.StudentId }).HasName("PK__Enroll__4A01231EB3DB2A91");

            entity.ToTable("Enroll");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrolls)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Enroll__CourseId__46E78A0C");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrolls)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Enroll__StudentI__47DBAE45");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorId).HasName("PK__Instruct__9D010A9B4F012C42");

            entity.HasIndex(e => e.Email, "UQ__Instruct__A9D10534830EE413").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);

            entity.HasMany(d => d.Courses).WithMany(p => p.Instructors)
                .UsingEntity<Dictionary<string, object>>(
                    "Teach",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK__Teach__CourseId__440B1D61"),
                    l => l.HasOne<Instructor>().WithMany()
                        .HasForeignKey("InstructorId")
                        .HasConstraintName("FK__Teach__Instructo__4316F928"),
                    j =>
                    {
                        j.HasKey("InstructorId", "CourseId").HasName("PK__Teach__F193DD81AAD5C822");
                        j.ToTable("Teach");
                    });
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Sections__80EF0872680CC077");

            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Course).WithMany(p => p.Sections)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Sections__Course__403A8C7D");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B9940635B20");

            entity.HasIndex(e => e.Email, "UQ__Students__A9D10534B408C74F").IsUnique();

            entity.Property(e => e.Education).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
