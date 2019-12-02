using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Pages;

namespace LocationMaster_API.Extensions
{
    public static class PageExtension
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
            int page, int pageSize) where T : class
        {
            var result = new PagedResult<T> {CurrentPage = page, PageSize = pageSize, RowCount = query.Count()};
            var pageCount = (double) result.RowCount / pageSize;
            result.PageCount = (int) Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();
            return result;
        }


        public static PagedResult<T> GetPagedResult<T, TKey>(this IQueryable<T> query, Func<T, TKey> predicate,
            int page, int pageSize, bool descending) where T : class
        {
            return query.GetPaged(page, pageSize);

        }
        
        public static PagedResult<T> GetPagedResultSearch<T, TKey>(this IQueryable<T> query, Func<T, TKey> predicate,
            int page, int pageSize, bool descending) where T : class
        {
            return query.GetPaged(page, pageSize);

        }

        
    }
}