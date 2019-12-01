using LocationMaster_API.Domain.Services;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Models;
using LocationMaster_API.Models.Entities;
using LocationMaster_API.Models.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationMaster_API.Services
{
    public class UserService : IUserService
    {

        private readonly UnitOfWork _unitOfWork;

        public UserService(LocationMasterContext locationMasterContext)
        {
            _unitOfWork = new UnitOfWork(locationMasterContext);
        }
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _unitOfWork.Users.ListAsync();
        }

        public async Task<SaveUserResponse> SaveAsync(User user)
        {
            try
            {
                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new SaveUserResponse(user);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveUserResponse($"An error occurred when saving the user: {ex.Message}");
            }

        }

        public async Task<SaveUserResponse> UpdateAsync(Guid id, SaveUserResponse user)
        {
            var existingUser = await _unitOfWork.Users.FindByIdAsync(id);

            if (existingUser == null)
                return new SaveUserResponse("User not found.");

            //UPDATE LOGIC HERE

            try
            {
                _unitOfWork.Users.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new SaveUserResponse(existingUser);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveUserResponse($"An error occurred when updating the user: {ex.Message}");
            }
        }
    }
}
