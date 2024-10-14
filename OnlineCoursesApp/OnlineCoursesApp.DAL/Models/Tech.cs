using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.DAL.Models
{
    // Many-to-Many join tables

    [Table("Tech")]
    public class Tech
    {
        [Key, Column(Order = 0)]
        public int InstructorID { get; set; }

        [Key, Column(Order = 1)]
        public int CourseID { get; set; }

        // Navigation properties
        public Instructor Instructor { get; set; } = new Instructor(); 
        public Course Course { get; set; } = new Course();
    }
}
