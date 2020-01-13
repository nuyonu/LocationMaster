using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocationMaster_API.Resources
{
    public class PlaceSave
    {
        public Guid OwnerId { get; set; }
        [Required] public string Name { get; set; }
        [Required] [MinLength(40)] public string Description { get; set; }
        [Required]public double TicketPrice { get; set; }
        [Required]public string Address { get; set; }
        [Required]public double Lat { get; set; }
        [Required]public double Ltn { get; set; }
        public List<string> Tags { get; private set; }
        public string Category { get; set; }
        public Dictionary<string, byte[]> PhotosContentStreams { get;  set; }

        public PlaceSave()
        {
        }
    }
}