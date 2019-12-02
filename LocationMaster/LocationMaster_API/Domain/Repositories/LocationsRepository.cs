using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Repositories.Repositories;
using LocationMaster_API.Extensions;
using LocationMaster_API.Pages;

namespace LocationMaster_API.Domain.Repositories
{
    public class LocationsRepository : Repository<Place>, ILocationRepository
    {
        public LocationsRepository(LocationMasterContext context) : base(context)
        {
            _dbEntities = context;
        }


        public IEnumerable<Place> GetBestPlaces(int amountOfPlaces)
        {
            return new List<Place>();
        }

       public PagedResult<Place> GetPage<TKey>(int page, int pageSize, bool @descending, string search,
            Func<Place, TKey> orderBy) where TKey : class
       {
           return _dbEntities.Places.GetPaged(page, pageSize);
//                Where(Search(search)).AsQueryable()
//                .GetPagedResult(orderBy, page, pageSize, descending);
       }


        private Func<Place, bool> Search(string search)
        {
            return s => s.Owner.Email.ToLower().Contains(search) ||
                        s.Owner.Username.ToLower().Contains(search) ||
                        s.Category.Name.ToLower().Contains(search) ||
                        s.LocationName.ToLower().Contains(search);
        }

        private readonly LocationMasterContext _dbEntities;
    }
}