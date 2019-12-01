using System.Collections.Generic;
using LocationMaster_API.Models.Entities;

namespace LocationMaster_API.Models.Repository.IRepository
{
    public interface ILocationRepository:IRepository<Place>
    {
        IEnumerable<Place> GetBestPlaces(int amountOfPlaces);

    }
}