using LocationMaster_API.Domain.Services;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Domain;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationMaster_API.Services.IServices;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LocationMaster_API.Resources;

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
                return new UserResponse($"An error occurred when deleting the user: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _unitOfWork.Users.GetAllUsersAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            var existingUser = await _unitOfWork.Users.FindByUsernameAsync(user.Username);

            if (existingUser != null)
                return new UserResponse("Username is already used.");

            try
            {
                user.SetProfileImage(Photo.Create("/StaticFiles/Images/ProfileImages/DefaultProfileImage.png"));
                await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
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
                return new UserResponse($"An error occurred when updating the user: {ex.Message}");
            }
        }

        public async Task<bool> CredentialsAreValidAsync(string username, string password)
        {
            var existingUser = await _unitOfWork.Users.FindByUsernameAsync(username);

            if (existingUser == null)
                return false;

            if (SecurePasswordHasherHelperService.Verify(password, existingUser.Password))
                return true;
            return false;
        }

        public async Task<UserToken>  CreateTokenAsync(string username, IConfiguration _configuration)
        {
            User user = await _unitOfWork.Users.FindByUsernameAsync(username);

            DateTime issueTime = DateTime.UtcNow;

            // Add required and basic JWT claims to the token
            List<Claim> claims = new List<Claim>
          {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUniversalTime().ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("userId", user.UserId.ToString())
          };
            // Add our users roles to the JWT
            // DO NOT Change this claim name, ASP.NET core role auth requires this exact claim name for controller roles
            claims.AddRange(
              user.AllowedRoles
              .Select(role => new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", role, ClaimValueTypes.String)));

            // Build the actual token
            //int expiryLengthInMinutes = Convert.ToInt32(_configuration["JwtExpiryInMinutes"]);
            int expiryLengthInMinutes = 30;
            DateTime now = DateTime.UtcNow;
            TimeSpan expirationTime = new TimeSpan(0, expiryLengthInMinutes, 0);
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtSecurityKey"]));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
              _configuration["JwtIssuer"],
              _configuration["JwtIssuer"],
              claims,
              expires: now.Add(expirationTime),
              signingCredentials: signingCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // Create response and send token back to caller
            var response = new UserToken(encodedJwt, DateTime.Now.Add(expirationTime));

            return response;
        }

        public async Task<UserResponse> FindByIdIncludePhotoAsync(Guid id)
        {
            var existingUser = await _unitOfWork.Users.FindByIdIncludePhotoAsync(id);

            if (existingUser == null)
                return new UserResponse("User not found");

            return new UserResponse(existingUser);
        }
    }
}