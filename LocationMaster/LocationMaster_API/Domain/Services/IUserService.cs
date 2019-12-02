using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationMaster_API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(Guid id, User user);
        Task<UserResponse> DeleteAsync(Guid id);
    }
}
