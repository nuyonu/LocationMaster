using LocationMaster_API.Models.Entities;
using LocationMaster_API.Models.Repository.IRepository;

namespace LocationMaster_API.Models.Repository
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