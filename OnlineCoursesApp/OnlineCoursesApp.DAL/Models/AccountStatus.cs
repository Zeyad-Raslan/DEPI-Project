using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesApp.DAL.Models
{
    public enum AccountStatus
    {
        Active,         // The account is active and in good standing
        Inactive,       // The account is inactive, possibly due to user inactivity
        Suspended,      // The account is temporarily suspended due to some issue
        Pending,        // The account is pending activation (e.g., email confirmation)
        Banned,         // The account is permanently banned
        Deleted         // The account has been deleted but might be recoverable
    }
}
