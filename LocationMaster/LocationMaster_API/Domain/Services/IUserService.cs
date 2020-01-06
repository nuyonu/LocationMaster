using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using LocationMaster_API.Resources;

namespace LocationMaster_API.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(Guid id, User user);
        Task<UserResponse> DeleteAsync(Guid id);
        Task<bool> CredentialsAreValidAsync(string username, string password);
        Task<UserToken> CreateTokenAsync(string username, IConfiguration _configuration);
        Task<UserResponse> FindByIdIncludePhotoAsync(Guid id);
    }
}