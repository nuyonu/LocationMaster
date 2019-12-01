using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationMaster_API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<SaveUserResponse> SaveAsync(User user);
        Task<SaveUserResponse> UpdateAsync(Guid id, User user);
    }
}
