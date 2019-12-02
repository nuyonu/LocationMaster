using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;

namespace LocationMaster_API.Domain.Entities
{
    public class Place
    {
        private Place()
        {
            //EF Core
        }
        public Guid PlaceId { get; private set; }
        public User Owner { get; private set; }
        public string LocationName { get; private set; }
        public string Description { get; private set; }
        public Category Category { get; private set; }
        public float TicketPrice { get; private set; }
        public double Longitude { get; private set; }
        public double Latitude { get; private set; }
        public List<Attraction> Attractions { get; private set; }
        public List<Photo> Photos { get; private set; }
        public List<Review> Reviews { get; private set; }

        public Place Create(User owner, string locationName, string description, Category category, float ticketPrice)
        {
            return new Place
            {
                PlaceId = Guid.NewGuid(),
                Owner = owner,
                LocationName = locationName,
                Description = description,
                Category = category,
                TicketPrice = ticketPrice
            };
        }
    }
}
