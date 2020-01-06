using System;
using System.Linq;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Pages;

namespace LocationMaster_API.Extensions
{
    internal static class PageExtension
    {
        internal static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
            int page, int pageSize) where T : class
        {
            var result = new PagedResult<T> {CurrentPage = page, PageSize = pageSize, RowCount = query.Count()};
            var pageCount = (double) result.RowCount / pageSize;
            result.PageCount = (int) Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();
            return result;
        }

        internal static IQueryable<Place> CustomSearch(this IQueryable<Place> query, string search)
        {
            return query.Where(s => (s.Owner.Email.ToLower().Contains(search) ||
                                     s.Owner.Username.ToLower().Contains(search) ||
                                     s.Category.Name.ToLower().Contains(search) ||
                                     s.LocationName.ToLower().Contains(search)));
        }


        internal static bool valid(Place place, int priceValue, int rating)
        {
            var price = false;

            switch (priceValue)
            {
                case 1:
                    price = place.TicketPrice <= 10;
                    break;
                case 2:
                    price = place.TicketPrice > 10 && place.TicketPrice <= 100;
                    break;
                case 3:
                    price = place.TicketPrice > 100 && place.TicketPrice <= 500;
                    break;
                case 4:
                    price = place.TicketPrice > 500;
                    break;
                default:
                    price = false;
                    break;
            }

            var ratingSelection = true;
            if (rating != 0)
            {
                var avg = place.Reviews.Average(s => s.Rating);
                ratingSelection = avg <= rating && avg > rating - 1;
            }

            return price && ratingSelection;
        }


        internal static IQueryable<Place> CustomOrderPlace(this IQueryable<Place> query, string orderBy,
            bool descending)
        {
            if (orderBy.ToLower() == "price")
                return @descending
                    ? query.OrderByDescending(s => s.TicketPrice).AsQueryable()
                    : query.OrderBy(s => s.TicketPrice).AsQueryable();
            return @descending
                ? query.OrderByDescending(GetOrderParameterString(orderBy)).AsQueryable()
                : query.OrderBy(GetOrderParameterString(orderBy)).AsQueryable();
        }

        private static Func<Place, string> GetOrderParameterString(string name)
        {
            switch (name.ToLower())
            {
                case "owner":
                    return s => s.Owner.Username;
                case "category":
                    return s => s.Category.Name;
                default:
                    return s => s.LocationName;
            }
        }
    }
}