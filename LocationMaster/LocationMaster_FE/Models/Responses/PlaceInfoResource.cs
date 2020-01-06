using System;
using System.Collections.Generic;

namespace LocationMaster_FE.Models.Responses
{
    public class PlaceInfoResource
    {
        public Guid PlaceId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public float TicketPrice { get; set; }
        public bool Deleted { get; set; }
        public string Address { get; set; }
        public Dictionary<string, double> location { get; set; }
        public Dictionary<string, string> Photos { get; set; }

        public PlaceInfoResource()
        {
        }

        public PlaceInfoResource(PlaceInfoResource info)
        {
            PlaceId = info.PlaceId;
            OwnerId = info.OwnerId;
            Name = info.Name;
            Description = info.Description;
            Category = info.Category;
            TicketPrice = info.TicketPrice;
//            location = new Dictionary<string, double>(info.location);
        }
    }
}