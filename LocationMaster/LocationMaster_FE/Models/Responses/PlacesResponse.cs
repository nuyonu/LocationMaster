namespace LocationMaster_FE.Models.Responses
{
    public class PlacesResponse : BaseResponse
    {
        public PagedResult _pagedResult { get; set; }

        public PlacesResponse()
        {
            _pagedResult = new PagedResult();
        }


        public void SetPlacesResponse(PlacesResponse response)
        {
            _pagedResult.SetPagedResult(response._pagedResult);
        }
    }
}