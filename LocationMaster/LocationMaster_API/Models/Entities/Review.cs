using System;

namespace LocationMaster_API.Models.Entities
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
