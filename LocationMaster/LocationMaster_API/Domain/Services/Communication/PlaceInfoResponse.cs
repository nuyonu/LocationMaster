using System;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Resources;

namespace LocationMaster_API.Domain.Services.Communication
{
    public class PlaceInfoResponse : BaseResponse
    {
        private PlaceInfoResponse( bool success, string message) : base(success, message)
        {
        }


        internal PlaceInfoResponse(Place place) : this( true, String.Empty)
        {
            data = new PlaceInfoResource(place);
            Message = "Operation completed";
        }

       
        internal PlaceInfoResponse(string message) : base(false, message)
        {
        }

        public PlaceInfoResource data { get; private set; }
    }
}