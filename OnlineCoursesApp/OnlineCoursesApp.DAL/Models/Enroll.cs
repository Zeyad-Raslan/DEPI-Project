using System;
using System.Collections.Generic;

namespace OnlineCoursesApp.DAL.Models;

public partial class Enroll
{
    public int CourseId { get; set; }

    public int StudentId { get; set; }

    public int? Progress { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
