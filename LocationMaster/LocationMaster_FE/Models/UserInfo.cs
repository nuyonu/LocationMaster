using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LocationMaster_FE.Models
{
    public class UserInfo
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
 
    }
}
