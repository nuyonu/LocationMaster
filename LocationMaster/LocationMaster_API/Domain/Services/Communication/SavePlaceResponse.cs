using System;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Resources;

namespace LocationMaster_API.Reponses
{
    public class SavePlaceResponse : BaseResponse
    {
        public SavePlaceResponse(PlaceInfoResource placeInfoResource, string message, bool success) : base(success, message)
        {
            PlaceInfoResource = placeInfoResource;
        }

        public SavePlaceResponse(PlaceInfoResource place) : this(place, String.Empty, false)
        {
        }

        public SavePlaceResponse(string message) : this(null, message, false)
        {
        }

        public PlaceInfoResource PlaceInfoResource;
    }
} 