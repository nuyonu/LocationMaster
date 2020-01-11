using System;

namespace LocationMaster_API.Domain.Entities
{
    public class User
    {
        private User()
        {
            //EF
        }

        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public Photo ProfileImage { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string[] AllowedRoles { get; set; }

        public static User Create(string username, string password, string email, string lastName, string firstName, DateTime birthDate, string[] allowedRoles)
        {
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = username,
                Password = password,
                Email = email,
                LastName = lastName,
                FirstName = firstName,
                BirthDate = birthDate,
                AllowedRoles = allowedRoles
            };
            return user;
        }

        public void SetProfileImage(Photo profileImage)
        {
            ProfileImage = profileImage;
        }

        internal void setNewLastName(string lastName)
        {
            this.LastName = lastName;
        }

        internal void setNewFirstName(string firstName)
        {
            this.FirstName = firstName;
        }

        internal void setNewEmail(string email)
        {
            this.Email = email;
        }

        internal void setNewBirthDate(DateTime birthDate)
        {
            this.BirthDate = birthDate;
        }
    }
}