using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.DAL.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Type { get; set; } = null!;

        public string? Image { get; set; }

        [StringLength(500)]
        public string Description { get; set; } = null!;

        public CourseStatus Status { get; set; } = CourseStatus.UnderReview;

        // Navigation properties
        public ICollection<Enroll> Enrollments { get; set; } = new List<Enroll>();
        public ICollection<Tech> Techs { get; set; } = new List<Tech>();
        public ICollection<Section> Sections { get; set; } = new List<Section>();
        public ICollection<StudentProgress> StudentProgresses { get; set; } = new List<StudentProgress>();

    }
}
