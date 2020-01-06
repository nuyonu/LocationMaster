using System;
using LocationMaster_API.Domain.Entities;

namespace LocationMaster_API.Resources
{
    public class AttractionsResource
    {
        public Guid AttractionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }

        public static AttractionsResource CreateResource(Attraction entity)
        {
            return new AttractionsResource()
            {
                AttractionId = entity.AttractionId,
                Description = entity.Description,
                Name = entity.Name,
                Photo = new byte[0]
            };
        }
    }
}