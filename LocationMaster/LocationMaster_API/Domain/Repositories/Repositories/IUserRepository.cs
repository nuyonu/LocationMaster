using LocationMaster_API.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocationMaster_API.Domain.Repositories.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> FindByUsername(string username);
    }
}