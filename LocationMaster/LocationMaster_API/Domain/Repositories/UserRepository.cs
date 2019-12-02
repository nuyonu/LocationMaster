using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Repository.IRepository;

namespace LocationMaster_API.Domain.Repository
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