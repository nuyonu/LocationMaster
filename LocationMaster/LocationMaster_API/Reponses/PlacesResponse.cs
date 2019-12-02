using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Pages;

namespace LocationMaster_API.Reponses
{
    public class PlacesResponse
    {
        public PlacesResponse(PagedResult<Place> getPageByTicketPrice)
        {
        }

        public PlacesResponse(string getPageByTicketPrice)
        {
        }
    }
}