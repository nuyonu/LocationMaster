using System;
using System.Collections.Generic;
using LocationMaster_API.Domain.Entities;

namespace LocationMaster_API.Resources
{
    public class PlaceInfoResource
    {
        public PlaceInfoResource(Place place)
        {
            PlaceId = place.PlaceId;
            OwnerId = place.Owner.UserId;
            Name = place.LocationName;
            Description = place.Description;
            Category = place.Category.Name;
            TicketPrice = place.TicketPrice;
            location = new Dictionary<string, double>
            {
                {"Longitude", place.Longitude}, {"Latitude", place.Latitude}
            };
            Photos=new Dictionary<string, string>();
            foreach (var photo in place.Photos)
            {
                Photos.Add(photo.PhotoId.ToString(),photo.Path);
            }
            Address = place.Address;
        }

        public Guid PlaceId { get; private set; }
        public Guid OwnerId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public float TicketPrice { get; private set; }
        public string Address { get; private set; }
        public Dictionary<string, double> location { get; private set; }
        public Dictionary<string, string> Photos { get; private set; }
    }
}