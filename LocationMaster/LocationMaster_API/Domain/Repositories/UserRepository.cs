using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Repositories.Repositories;

namespace LocationMaster_API.Domain.Repositories
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