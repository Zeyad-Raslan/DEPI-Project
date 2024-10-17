using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCoursesApp.DAL.Models;

public partial class Instructor
{
    [Key]
    public int InstructorId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string About { get; set; } = null!;

    public string? Image { get; set; }
    public virtual ICollection<Course> Courses { get; set; }

    // for authentication 
    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }
    public virtual ApplicationUser ApplicationUser { get; set; }
    public Instructor()
    {
        Courses = new HashSet<Course>();
    }
}
