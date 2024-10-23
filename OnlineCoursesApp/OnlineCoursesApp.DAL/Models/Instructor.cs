using Microsoft.AspNetCore.Identity;
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
    public AccountStatus AccountStatus { get; set; } = AccountStatus.Active;

    // public string Password { get; set; } = null!;

    public string? About { get; set; }

    public string? Image { get; set; } = "/image/Instructor/default.png";
    public virtual ICollection<Course> Courses { get; set; }

    // for authentication 
    [ForeignKey("IdentityUser")]
    public string IdentityUserID { get; set; }
    public virtual IdentityUser IdentityUser { get; set; }
    public Instructor()
    {
        Courses = new HashSet<Course>();
    }
}
