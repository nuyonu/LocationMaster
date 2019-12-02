using System.Collections.Generic;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Repository.IRepository;

namespace LocationMaster_API.Domain.Repository
{
    public class LocationsRepository:Repository<Place>,ILocationRepository
    {
        public LocationsRepository(LocationMasterContext context) : base(context)
        {
            _dbEntities = context;
        }


        public IEnumerable<Place> GetBestPlaces(int amountOfPlaces)
        {
            return  new List<Place>();
        }


        private readonly LocationMasterContext _dbEntities;

    }
}