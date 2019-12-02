using LocationMaster_API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationMaster_API.Domain.Entities;

namespace LocationMaster_API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<SaveUserResponse> SaveAsync(User user);
        Task<SaveUserResponse> UpdateAsync(Guid id, User user);
    }
}
