using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.DAL.Models
{
    public class BlackList
    {
        [Key]
        public string Email { get; set; } = null!;

    }
}
