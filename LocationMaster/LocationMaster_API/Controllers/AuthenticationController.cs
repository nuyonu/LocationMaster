using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Services;
using LocationMaster_API.Domain.UnitOfWork;
using LocationMaster_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LocationMaster_API.Controllers
{

    [ApiVersion("1.0")]
    [Route("/api/v{v:apiVersion}/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        public AuthenticationController(ILogger<UsersController> logger, IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginResource login)
        {
            bool credentialsAreValid = await _userService.CredentialsAreValidAsync(login.Username, login.Password);
           if (!credentialsAreValid)
                return BadRequest("Username and password are invalid.");
            Console.WriteLine("AICI ADASDAS \n\n\n\n");
            UserToken tokenResult = await _userService.CreateTokenAsync(login.Username, _configuration);
            return Ok(tokenResult);
        }
    }
}
