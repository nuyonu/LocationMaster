using System;

namespace LocationMaster_API.Resources
{
    public class PlaceViewResource
    {
        public Guid PlaceId { get; private set; }
        public string LocationName { get; private set; }
        public double Longitude { get; private set; }
        public double Latitude { get; private set; }
        public  int AverageReview { get; private set; }

    }
}