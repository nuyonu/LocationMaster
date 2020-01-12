using System;
using LocationMaster_API.Resources;

namespace LocationMaster_API.Domain.Entities
{
    public class Attraction
    {
        public Guid AttractionId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Photo Photo { get; private set; }

        public static Attraction Create(string name, string description, Photo photo)
        {
            return new Attraction
            {
                AttractionId = Guid.NewGuid(),
                Name = name,
                Description = description,
                Photo = photo
            };
        }

        public void Update(UpdateAttractionRequest request)
        {
            Name = request.Name;
            Description = request.Description;
        }
    }
}