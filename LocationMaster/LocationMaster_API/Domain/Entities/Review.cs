using System;
using LocationMaster_API.Domain.Entities;

namespace LocationMaster_API.Domain.Entities
{
    public class Review
    {
        private Review()
        {
            //EF Core
        }
        public Guid ReviewId { get; private set; }
        public User User { get; private set; }
        public int Rating { get; private set; }

        public Review Create(User user, int rating)
        {
            return new Review
            {
                ReviewId = Guid.NewGuid(),
                User = user,
                Rating = rating
            };
        }
    }
}
