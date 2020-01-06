using System.Collections.Generic;

namespace LocationMaster_FE.Models.Responses
{
    public class PagedResult : PagedResultBase
    {
        public List<PlaceInfoResource> Results { get; set; }

        public PagedResult()
        {
            Results=new List<PlaceInfoResource>();
            Results.Add(new PlaceInfoResource());
            Results.Add(new PlaceInfoResource());
            Results.Add(new PlaceInfoResource());
            Results.Add(new PlaceInfoResource());
            Results.Add(new PlaceInfoResource());
        }

        public void SetPagedResult(PagedResult result)
        {
            CurrentPage = result.CurrentPage;
            PageCount = result.PageCount;
            PageSize = result.PageSize;
            RowCount = result.RowCount;
            Results.Clear();
            foreach (var place in result.Results)
            {
                Results.Add(new PlaceInfoResource(place));
            }
        }
    }
}