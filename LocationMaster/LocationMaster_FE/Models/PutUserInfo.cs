using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LocationMaster_FE.Models.CustomValidations;

namespace LocationMaster_FE.Models
{
    public class PutUserInfo
    {
        public string Username { get; set; }
        [Required]
        [MaxLength(124)]
        [EmailAddress(ErrorMessage = "Email is invalid.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name must be betweeen 5 and 50 characters", MinimumLength = 5)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "First name must be betweeen 5 and 100 characters", MinimumLength = 5)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Birth of date is required")]
        [DateOfBirth(MinAge = 10, MaxAge = 150, ErrorMessage = "Your age must be between 10 and 150 years")]
        public DateTime BirthDate { get; set; }
    }
}
