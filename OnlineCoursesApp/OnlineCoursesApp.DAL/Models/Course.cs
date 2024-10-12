using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineCoursesApp.DAL.Models;

public partial class Course
{
    [Key]
    public int CourseId { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Description { get; set; } = null!;

    public CourseStatus CourseStatus { get; set; } = CourseStatus.UnderReview;

    public string? Image { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual Instructor Instructor { get; set; }
    public Course()
    {
        Sections = new HashSet<Section>();
        Students = new HashSet<Student>();
    }
}
