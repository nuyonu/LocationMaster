using NetTopologySuite.Geometries;
using System;

namespace LocationMaster_API.Models
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

        public static User Create(string username, string password, string email, string lastName, string firstName)
        {
            return new User
            {
                UserId = Guid.NewGuid(),
                Username = username,
                Password = password,
                Email = email,
                LastName = lastName,
                FirstName = firstName
            };
        }
    }
}
