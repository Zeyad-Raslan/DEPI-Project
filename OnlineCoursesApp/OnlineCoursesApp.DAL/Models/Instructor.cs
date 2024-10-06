using System;
using System.Collections.Generic;

namespace OnlineCoursesApp.DAL.Models;

public partial class Instructor
{
    public int InstructorId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string About { get; set; } = null!;

    public string? Image { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
