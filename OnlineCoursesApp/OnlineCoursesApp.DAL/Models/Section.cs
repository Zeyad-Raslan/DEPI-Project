using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.DAL.Models
{
    [Table("Section")]
    public class Section
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int CourseID { get; set; }  // Weak entity key, related to Course

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        [Url]
        public string Link { get; set; } = null!;

        [Range(1, 1000)]
        public int Num { get; set; }

        // Navigation property
        public Course Course { get; set; } = new Course();
        public ICollection<StudentProgress> StudentProgresses { get; set; } = new List<StudentProgress>();
    }
}
