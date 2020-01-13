using System;
using LocationMaster_API.Pages;
using LocationMaster_API.Resources;

namespace LocationMaster_API.Domain.Services.Communication
{
    public class PlacesResponse : BaseResponse
    {
        public PagedResult<PlaceInfoResource> _pagedResult { get; private set; }

        private PlacesResponse(PagedResult<PlaceInfoResource> pagedResult, bool success, string message) : base(success, message)
        {
            _pagedResult = pagedResult;
        }

        public PlacesResponse(PagedResult<PlaceInfoResource> pagedResult) : this(pagedResult, true, string.Empty)
        {
            Console.WriteLine("Here 10");
            Console.WriteLine(Success);
        }

        public PlacesResponse(string message) : this(null, false, message)
        {
        }
    }
}