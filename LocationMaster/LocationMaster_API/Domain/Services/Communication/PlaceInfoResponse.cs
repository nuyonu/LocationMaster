using System;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Resources;

namespace LocationMaster_API.Domain.Services.Communication
{
    public class PlaceInfoResponse : BaseResponse
    {
        private PlaceInfoResponse(int code, bool success, string message) : base(success, message)
        {
        }


        internal PlaceInfoResponse(Place place) : this(200, true, String.Empty)
        {
            InfoResource = new PlaceInfoResource(place);
            _code = 200;
            Message = "Operation completed";
        }

        internal PlaceInfoResponse(int code) : base(false, String.Empty)
        {
            if (code == 400)
                Message = "Place not found";
        }

        internal PlaceInfoResponse(string message) : base(false, message)
        {
        }

        public int _code { get; private set; }
        public PlaceInfoResource InfoResource { get; private set; }
    }
}