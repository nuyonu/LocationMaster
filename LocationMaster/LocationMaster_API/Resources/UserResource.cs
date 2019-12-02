using System;
using LocationMaster_API.Domain.Entities;

namespace LocationMaster_API.Resources
{
    public class UserResource
    {
        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public Photo ProfileImage { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public DateTime BirthDate { get; private set; }

    }
}
