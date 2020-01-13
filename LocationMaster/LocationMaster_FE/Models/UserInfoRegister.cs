using LocationMaster_FE.Models.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocationMaster_FE.Models
{
    public class UserInfoRegister
    {
        [Required]
        [StringLength(30,ErrorMessage = "Username must be betweeen 5 and 30 characters", MinimumLength = 5)]
        public string Username { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 128 characters")]
        public string Password { get; set; }
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
        [DateOfBirth(MinAge = 10, MaxAge = 150, ErrorMessage ="Your age must be between 10 and 150 years")]
        public DateTime BirthDate { get; set; }
    }
}
