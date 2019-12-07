using System;
using System.ComponentModel.DataAnnotations;

namespace LocationMaster_API.Resources
{
    public class SavePlaceResource
    {
        [Required] public Guid OwnerId { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        [MinLength(30)]
        public string Description { get; set; }

        [Required] public string Category { get; set; }
        [Required] public double Longitude { get; set; }
        [Required] public double Latitude { get; set; }
        [Required] public float TicketPrice { get; set; }
    }
}