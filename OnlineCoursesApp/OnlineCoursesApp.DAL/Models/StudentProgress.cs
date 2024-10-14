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
<<<<<<< HEAD
        public bool Status {  get; set; }
=======
        public bool Status {  get; set; }=false;
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f

        public Section Section { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
