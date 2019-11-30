using LocationMaster_API.Models.Entities;
using LocationMaster_API.Models.Repository.IRepository;

namespace LocationMaster_API.Models.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(LocationMasterContext context) : base(context)
        {
            _context = context;
        }

        private readonly LocationMasterContext _context;
    }
}