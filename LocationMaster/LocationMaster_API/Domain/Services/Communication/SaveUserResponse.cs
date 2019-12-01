using LocationMaster_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationMaster_API.Domain.Services.Communication
{
    public class SaveUserResponse : BaseResponse
    {
        public User User { get; private set; }

        private SaveUserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }

        public SaveUserResponse(User user) : this(true, string.Empty, user)
        { }

        public SaveUserResponse(string message) : this(false, message, null)
        { }
    }
}
