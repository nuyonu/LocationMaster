using LocationMaster_API.Domain.Services;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Domain;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
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

        public async Task<UserResponse> DeleteAsync(Guid id)
        {
            var existingUser = await _unitOfWork.Users.FindByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("User not found.");

            try
            {
                _unitOfWork.Users.Remove(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new UserResponse($"An error occurred when deleting the user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _unitOfWork.Users.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new UserResponse($"An error occurred when saving the user: {ex.Message}");
            }

        }

        public async Task<UserResponse> UpdateAsync(Guid id, User user)
        {
            var existingUser = await _unitOfWork.Users.FindByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("User not found.");

            //UPDATE LOGIC HERE

            try
            {
                _unitOfWork.Users.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new UserResponse($"An error occurred when updating the user: {ex.Message}");
            }
        }
    }
}
