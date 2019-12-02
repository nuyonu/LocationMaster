using System;
using System.Collections.Generic;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Pages;

namespace LocationMaster_API.Domain.Repositories.Repositories
{
    public interface ILocationRepository : IRepository<Place>
    {
        IEnumerable<Place> GetBestPlaces(int amountOfPlaces);

        PagedResult<Place> GetPage<TKey>(int page, int pageSize, bool @descending, string search,
            Func<Place, TKey> orderBy) where TKey : class;
    }
}