using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.DAL.Models
{

    [Table("Instructor")]
    public class Instructor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = null!;

        [StringLength(500)]
        public string About { get; set; } = null!;

        public string? Image { get; set; }


        // Navigation properties
        public ICollection<Tech> Techs { get; set; } = new List<Tech>();

    }
}
