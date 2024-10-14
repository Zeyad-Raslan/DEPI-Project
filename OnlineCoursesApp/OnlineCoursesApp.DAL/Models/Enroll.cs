using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.DAL.Models
{
    [Table("Enroll")]
    public class Enroll
    {
        [Key, Column(Order = 0)]
        public int StudentID { get; set; }

        [Key, Column(Order = 1)]
        public int CourseID { get; set; }

        // Navigation properties
        public Student Student { get; set; } = new Student();
        public Course Course { get; set; } = new Course();
    }


}
