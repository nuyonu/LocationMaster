using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel.DataAnnotations;
using LocationMaster_FE.Models.Responses;

namespace LocationMaster_FE.Models
{
    public class PlaceSave
    {
        public Guid OwnerId { get; set; }
        [Required] public string Name { get; set; }
        [Required] [MinLength(40)] public string Description { get; set; }
        public double TicketPrice { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Ltn { get; set; }
        public List<string> Tags { get; private set; }
        public string Category { get; set; }
        public Dictionary<string, byte[]> PhotosContentStreams { get; private set; }

        public PlaceSave()
        {
            OwnerId = new Guid("f6d6642e-8e2b-411a-a490-3fe4258d3743");
            Tags = new List<string>();
            PhotosContentStreams = new Dictionary<string, byte[]>();
        }

         public static PlaceSave Create(PlaceInfoResource place)
         {
             return new PlaceSave()
             {
                 OwnerId = place.OwnerId,
                 Name = place.Name,
                 Description = place.Description,
                 TicketPrice = place.TicketPrice,
                 Address = place.Address,
                 Lat = place.location["Latitude"],
                 Ltn = place.location["Longitude"],
                 Category = place.Category
             };

         }
    }
}