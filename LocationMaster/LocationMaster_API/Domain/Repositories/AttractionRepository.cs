using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Repository.IRepository;

namespace LocationMaster_API.Domain.Repository
{
    public class AttractionRepository:Repository<Attraction>,IAttractionRepository
    {
        public AttractionRepository(LocationMasterContext dbEntities):base(dbEntities)
        {
            _dbEntities = dbEntities;
        }

        private readonly LocationMasterContext _dbEntities;
    }
}

