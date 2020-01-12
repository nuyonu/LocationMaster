using LocationMaster_API.Domain.Services;
using LocationMaster_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace LocationMaster_API.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{v:apiVersion}/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthenticationController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginResource login)
        {
            bool credentialsAreValid = await _userService.CredentialsAreValidAsync(login.Username, login.Password);
            if (!credentialsAreValid)
                return BadRequest("Username and password are invalid.");
            UserToken tokenResult = await _userService.CreateTokenAsync(login.Username, _configuration);
            return Ok(tokenResult);
        }
    }
}