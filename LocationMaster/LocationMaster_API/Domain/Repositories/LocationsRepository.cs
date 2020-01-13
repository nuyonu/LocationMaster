using System;
using System.Collections.Generic;
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
                ? _dbEntities.Places.Include(s => s.Category).Include(s => s.Owner).Include(s => s.Photos)
                    .CustomOrderPlace(orderBy, @descending).GetPaged(page, pageSize)
                : _dbEntities.Places.Include(s => s.Category).Include(s => s.Owner).Include(s => s.Photos).CustomSearch(search)
                    .CustomOrderPlace(orderBy, @descending)
                    .GetPaged(page, pageSize);
        }

        public Place GetById(Guid id)
        {
            var temp = _dbEntities.Places.Include(s => s.Category)
                .Include(s => s.Owner).Include(p=>p.Attractions).ThenInclude(s=>s.Photo).Include(e=>e.Photos).Where(e=>e.PlaceId==id).ToList();
            return temp.Count == 0 ? null : temp.First();
        }

        public IEnumerable<Place> GetPlacesOfModerator(Guid id)
        {
            return _dbEntities.Places.Include(e => e.Owner).Include(e=>e.Category).Where(e => e.Owner.UserId == id).Include(e=>e.Photos).ToList();
        }

        public IEnumerable<Place> GetFirstPlacesByPrice(int count, bool ascending)
        {
            if (ascending)
                return _dbEntities.Places.Include(e => e.Owner).Include(e => e.Category).Include(e => e.Photos).OrderBy(e => e.TicketPrice).Take(count).ToList();
            return _dbEntities.Places.Include(e => e.Owner).Include(e => e.Category).Include(e => e.Photos).OrderByDescending(e => e.TicketPrice).Take(count).ToList();
        }

        private readonly LocationMasterContext _dbEntities;
    }
}