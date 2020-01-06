using LocationMaster_API.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Resources;

namespace LocationMaster_API.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{v:apiVersion}/[controller]")]
    public class ImagesController : Controller
    {
        private readonly ILogger<UsersController> logger;
        private readonly IImageService _imageService;

        public ImagesController(ILogger<UsersController> logger, IImageService imageService)
        {
            this.logger = logger;
            _imageService = imageService;
        }

        [HttpGet("{id}")]
        public async Task<byte[]> GetImageById(Guid id)
        {
            string path = await _imageService.GetPathById(id);
            byte[] result = await _imageService.GetFileByPath(path);
            return result;
        }

        [HttpGet("Places/{id}")]
        public Response<Dictionary<string, byte[]>> GetImagesForPlace(Guid id)
        {
            var response = _imageService.GetPathByPlaceId(id);
            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImageById(Guid id, [FromBody] ImagePut image)
        {
            if (image == null || image.ImageStringBytes == null)
            {
                return BadRequest("Image can't be empty.");
            }

            var result = await _imageService.UpdateByIdAsync(id, image.ImageStringBytes);
            if (!result.Success)
                return BadRequest(result.Message);
            return NoContent();
        }
    }
}