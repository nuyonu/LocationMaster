using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Repositories.Repositories;

namespace LocationMaster_API.Domain.Repositories
{
    public class AttractionRepository : Repository<Attraction>, IAttractionRepository
    {
        public AttractionRepository(LocationMasterContext dbEntities) : base(dbEntities)
        {
            _dbEntities = dbEntities;
        }

        private readonly LocationMasterContext _dbEntities;
    }
}