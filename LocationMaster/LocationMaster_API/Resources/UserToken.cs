using System;

namespace LocationMaster_API.Resources
{
    public class UserToken
    {
        public UserToken(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
