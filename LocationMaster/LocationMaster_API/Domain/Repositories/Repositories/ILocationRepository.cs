using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Pages;

namespace LocationMaster_API.Domain.Repositories.Repositories
{
    public interface ILocationRepository : IRepository<Place>
    {
        PagedResult<Place> GetPage(int page, int pageSize, bool @descending, string search,
            string orderBy);

        Place GetById(Guid id);

        IEnumerable<Place> GetPlacesOfModerator(Guid id);

        IEnumerable<Place> GetFirstPlacesByPrice(int count, bool ascending);
    }
    
}