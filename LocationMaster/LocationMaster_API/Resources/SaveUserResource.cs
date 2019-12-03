using LocationMaster_API.Resources.CustomValidations;
using System;
using System.ComponentModel.DataAnnotations;

namespace LocationMaster_API.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [MaxLength(128)]
        public string Password { get; set; }
        [Required]
        [MaxLength(124)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [DateOfBirth(MinAge = 0, MaxAge = 150)]
        public DateTime BirthDate { get; set; }
    }
}
