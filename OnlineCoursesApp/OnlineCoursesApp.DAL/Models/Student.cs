﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineCoursesApp.DAL.Models;

public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Education { get; set; } = null!;

    public string? Image { get; set; }

    public virtual ICollection<Course> Courses { get; set; }

    public Student()
    {
        Courses = new HashSet<Course>();
    }
}
