using System.Collections.Generic;
using LocationMaster_API.Domain.Entities;

namespace LocationMaster_API.Domain.Repository.IRepository
{
    public interface ILocationRepository:IRepository<Place>
    {
        IEnumerable<Place> GetBestPlaces(int amountOfPlaces);

    }
}