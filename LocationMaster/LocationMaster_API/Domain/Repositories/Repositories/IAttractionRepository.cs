using System;
using System.Collections.Generic;
using LocationMaster_API.Domain.Entities;


namespace LocationMaster_API.Domain.Repositories.Repositories
{
    public interface IAttractionRepository : IRepository<Attraction>
    {
        IEnumerable<Attraction> GetAttractionsAsyncOfPlace(Guid id);
        Attraction GetWithPhoto(Guid id);
    }
}