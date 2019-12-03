using System;

namespace LocationMaster_API.Domain.Entities
{
    public class Photo
    {
        private Photo()
        {
            //EF Core
        }
        public Guid PhotoId { get; private set; }
        public string Path { get; private set; }
        public static Photo Create(string path)
        {
            return new Photo
            {
                PhotoId = Guid.NewGuid(),
                Path = path
            };
        }
    }
}