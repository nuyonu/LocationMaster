using System;
using System.Collections.Generic;

namespace LocationMaster_FE.Models.Responses
{
    public class DetailPlace
    {
        public Guid PlaceId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public float TicketPrice { get; set; }
        public string Address { get; set; }
        public Dictionary<string, double> location { get; set; }
    }
}