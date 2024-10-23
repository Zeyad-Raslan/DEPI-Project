using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCoursesApp.DAL.Models;

public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
    public AccountStatus AccountStatus { get; set; } = AccountStatus.Active;


    //public string Password { get; set; } = null!;

    public string? Education { get; set; }

    public string? Image { get; set; } = "/image/Student/default.png";

    public virtual ICollection<Course> Courses { get; set; }

    // for authentication 
    [ForeignKey("IdentityUser")]
    public string IdentityUserID { get; set; }
    public virtual IdentityUser IdentityUser { get; set; }
    public Student()
    {
        Courses = new HashSet<Course>();
    }
}
