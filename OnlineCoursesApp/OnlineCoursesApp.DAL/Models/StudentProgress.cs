using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.DAL.Models
{
    public class StudentProgress
    {
        [Key]
        public int Id { get; set; }
        public bool Status {  get; set; }=false;

        public Section Section { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
