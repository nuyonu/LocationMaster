using LocationMaster_API.Models.Entities;
using LocationMaster_API.Models.Repository.IRepository;

namespace LocationMaster_API.Models.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(LocationMasterContext context) : base(context)
        {
            _dbEntities = context;
        }

        private readonly LocationMasterContext _dbEntities;
    }
}