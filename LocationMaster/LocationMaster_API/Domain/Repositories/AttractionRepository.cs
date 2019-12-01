using LocationMaster_API.Models.Entities;
using LocationMaster_API.Models.Repository.IRepository;

namespace LocationMaster_API.Models.Repository
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

