using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    using System.ComponentModel.DataAnnotations;
namespace OnlineCoursesApp.DAL.Models
{

    public enum CourseType
    {
        [Display(Name = "Computer Science")]
        ComputerScience,

        [Display(Name = "Back End")]
        BackEnd,

        [Display(Name = "Front End")]
        FrontEnd,

        [Display(Name = "Programming Language")]
        ProgrammingLanguage,

        [Display(Name = "Data Science")]
        DataScience,

        [Display(Name = "Business")]
        Business,

        [Display(Name = "Marketing")]
        Marketing,

        [Display(Name = "Mathematics")]
        Mathematics,

        [Display(Name = "Physics")]
        Physics,

        [Display(Name = "Chemistry")]
        Chemistry,

        [Display(Name = "Biology")]
        Biology,

        [Display(Name = "Engineering")]
        Engineering,

        [Display(Name = "Humanities")]
        Humanities,

        [Display(Name = "Arts")]
        Arts,

        [Display(Name = "Languages")]
        Languages,

        [Display(Name = "Health")]
        Health,

        [Display(Name = "Finance")]
        Finance,

        [Display(Name = "Law")]
        Law,

        [Display(Name = "Social Sciences")]
        SocialSciences,

        [Display(Name = "Psychology")]
        Psychology,

        [Display(Name = "Education")]
        Education,

        [Display(Name = "IT and Software")]
        ITAndSoftware,

        [Display(Name = "Personal Development")]
        PersonalDevelopment
    }


}
