using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineCoursesApp.DAL.Models;

public partial class Section
{
    [Key]
    public int SectionId { get; set; }

    public string Title { get; set; } = null!;

    public string Link { get; set; } = null!;

    public int Number { get; set; }

    public virtual Course? Course { get; set; }
}
