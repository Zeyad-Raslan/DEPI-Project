using System;
using System.Collections.Generic;

namespace OnlineCoursesApp.DAL.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Education { get; set; } = null!;

    public string? Image { get; set; }

    public virtual ICollection<Enroll> Enrolls { get; set; } = new List<Enroll>();
}
