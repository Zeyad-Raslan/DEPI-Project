using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.DAL.Models
{
    [Table("StudentProgress")]
    public class StudentProgress
    {
        [Key]
        public int ID { get; set; }

       
        public int CourseID { get; set; }

        public int StudentID { get; set; }

        
        public int SectionID { get; set; }

        [Required]
        public bool IsCompleted { get; set; } = false; // Default value is false.

        // Navigation properties
        public Course Course { get; set; } = new Course();
        public Student Student { get; set; } = new Student();
        public Section Section { get; set; } = new Section();
    }
}
