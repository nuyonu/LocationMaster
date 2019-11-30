using System.Collections.Generic;
using LocationMaster_API.Models.Entities;
using LocationMaster_API.Models.Repository.IRepository;

namespace LocationMaster_API.Models.Repository
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