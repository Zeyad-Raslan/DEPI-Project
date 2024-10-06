using System;
using System.Collections.Generic;

namespace OnlineCoursesApp.DAL.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? Status { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Enroll> Enrolls { get; set; } = new List<Enroll>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
}
