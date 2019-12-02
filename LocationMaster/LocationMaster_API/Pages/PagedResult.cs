using System.Collections.Generic;

namespace LocationMaster_API.Pages
{
    public class PagedResult<T>:PagedResultBase where T : class    
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results=new List<T>();
        }
    }
}