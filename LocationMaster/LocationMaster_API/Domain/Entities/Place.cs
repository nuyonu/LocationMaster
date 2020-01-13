using System;
using System.Collections.Generic;
using LocationMaster_API.Resources;

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
        public string Address { get; set; }
        public List<Attraction> Attractions { get; private set; }
        public List<Photo> Photos { get; private set; }
        public List<Review> Reviews { get; private set; }

        public static Place Create(User owner, string locationName, string description, Category category,
            float ticketPrice)
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

        public static Place Create(User owner, string locationName, string description, Category category,
            float ticketPrice, string address, double latitude, double longitude)
        {
            return new Place
            {
                PlaceId = Guid.NewGuid(),
                Owner = owner,
                LocationName = locationName,
                Description = description,
                Category = category,
                TicketPrice = ticketPrice,
                Address = address,
                Latitude = latitude,
                Longitude = longitude,
                Photos = new List<Photo>(),
                Attractions = new List<Attraction>(),
                Reviews = new List<Review>()
            };
        }

        public void Update(PlaceSave value)
        {
            LocationName = value.Name;
            Description = value.Description;
            TicketPrice = Convert.ToSingle(value.TicketPrice);
            Address = value.Address;
            Latitude = value.Lat;
            Longitude = value.Ltn;
        }
    }
}