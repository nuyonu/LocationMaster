﻿using AutoMapper;
using LocationMaster_API.Domain.Services;
using LocationMaster_API.Extensions;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationMaster_API.Services.IServices;

namespace LocationMaster_API.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{v:apiVersion}/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            var result = await _userService.FindByIdIncludePhotoAsync(id);
            if (!result.Success)
                return NotFound(result.Message);

            var resource = _mapper.Map<User, UserResource>(result.User);
            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = LocationMaster_API.Domain.Entities.User.Create(resource.Username,
                            SecurePasswordHasherHelperService.Hash(resource.Password), resource.Email, resource.LastName, resource.FirstName, resource.BirthDate, new[] { "user" });

            var result = await _userService.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.User);
            return Created($"/api/v1/users/{userResource.UserId}", userResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] PutUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _userService.UpdateAsync(id, resource);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.User);
            return Ok(userResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}