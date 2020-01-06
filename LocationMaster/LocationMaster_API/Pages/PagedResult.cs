using System.Collections.Generic;

namespace LocationMaster_API.Pages
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }

        public static PagedResult<N> CopyPageInfo<N>(PagedResult<T> pages) where N : class
        {
            return new PagedResult<N>()
            {
                CurrentPage = pages.CurrentPage, PageCount = pages.PageCount, PageSize = pages.PageSize,
                RowCount = pages.RowCount
            };
        }

        public static PagedResult<N> NoContent<N>(PagedResult<T> pages) where N : class
        {
            
            return new PagedResult<N>()
            {
                CurrentPage = 0, PageCount = 0, PageSize = pages.PageSize, RowCount = 0
            };
        }
    }
}