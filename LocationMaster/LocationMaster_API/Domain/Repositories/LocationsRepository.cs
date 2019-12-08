using System;
using System.Linq;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Repositories.Repositories;
using LocationMaster_API.Extensions;
using LocationMaster_API.Pages;
using Microsoft.EntityFrameworkCore;

namespace LocationMaster_API.Domain.Repositories
{
    public class LocationsRepository : Repository<Place>, ILocationRepository
    {
        public LocationsRepository(LocationMasterContext context) : base(context)
        {
            _dbEntities = context;
        }


        public PagedResult<Place> GetPage(int page, int pageSize, bool @descending, string search,
            string orderBy)
        {
            return search == null
                ? _dbEntities.Places.Include(s => s.Category).Include(s => s.Owner)
                    .CustomOrderPlace(orderBy, @descending).GetPaged(page, pageSize)
                : _dbEntities.Places.Include(s => s.Category).Include(s => s.Owner).CustomSearch(search)
                    .CustomOrderPlace(orderBy, @descending)
                    .GetPaged(page, pageSize);
        }

        public Place GetById(Guid id)
        {
            var temp = _dbEntities.Places.Include(s => s.Category)
                .Include(s => s.Owner).ToList();
            return temp.Count == 0 ? null : temp.First();
        }


        private readonly LocationMasterContext _dbEntities;
    }
}