using LocationMaster_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
