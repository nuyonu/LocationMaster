using System;
using System.Collections.Generic;
using System.Linq;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LocationMaster_API.Domain.Repositories
{
    public class AttractionRepository : Repository<Attraction>, IAttractionRepository
    {
        public AttractionRepository(LocationMasterContext dbEntities) : base(dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public IEnumerable<Attraction> GetAttractionsAsyncOfPlace(Guid id)
        {
            if (_dbEntities.Places.Where(s => s.PlaceId == id).ToList().Count == 0)
                return new List<Attraction>();
            return _dbEntities.Places.Include(u => u.Attractions)
                .ThenInclude(s => s.Photo)
                .Where(p => p.PlaceId == id)
                .Select(s => s.Attractions)
                .First();
        }

        private readonly LocationMasterContext _dbEntities;
    }
}