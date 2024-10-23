using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.DAL.Models
{
    public class WebAdmin
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
        public AccountStatus AccountStatus { get; set; } = AccountStatus.Active;


        //public string Password { get; set; } = null!;

        // for authentication 
        [ForeignKey("IdentityUser")]
        public string IdentityUserID { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
