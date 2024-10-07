using System;
using System.Collections.Generic;

namespace OnlineCoursesApp.DAL.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public string Title { get; set; } = null!;

    public string Link { get; set; } = null!;

    public int Number { get; set; }

    public int? CourseId { get; set; }

    public virtual Course? Course { get; set; }
}
