using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Assignment.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AssignmentUser class
public class AssignmentUser : IdentityUser
{
 
    public string firstname { get; set; }
    
    public string lastname { get; set; }
}

