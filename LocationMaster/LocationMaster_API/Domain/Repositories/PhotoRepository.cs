using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Repository.IRepository;

namespace LocationMaster_API.Domain.Repository
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(LocationMasterContext context) : base(context)
        {
            _context = context;
        }

        private readonly LocationMasterContext _context;
    }
}