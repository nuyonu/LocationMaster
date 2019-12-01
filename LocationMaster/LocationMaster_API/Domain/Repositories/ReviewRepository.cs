using LocationMaster_API.Models.Entities;
using LocationMaster_API.Models.Repository.IRepository;

namespace LocationMaster_API.Models.Repository
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(LocationMasterContext context) : base(context)
        {
            _context = context;
        }

        private readonly LocationMasterContext _context;
    }
}