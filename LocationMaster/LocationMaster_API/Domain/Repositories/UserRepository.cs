using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LocationMaster_API.Domain.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(LocationMasterContext context) : base(context)
        {
            _dbEntities = context;
        }

        private readonly LocationMasterContext _dbEntities;

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbEntities.Users.Include(u => u.ProfileImage)
                                          .ToListAsync();
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _dbEntities.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> FindByIdIncludePhotoAsync(Guid id)
        {
            return await _dbEntities.Users.Include(u => u.ProfileImage)
                    .FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}