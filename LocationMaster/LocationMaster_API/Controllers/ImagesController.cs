using LocationMaster_API.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImageById(Guid id,[FromBody] ImagePut image)
        {
            Console.WriteLine(id);
            if(image == null)
            {
                Console.WriteLine("NULL\n\n");
            }
            else
            {
                Console.WriteLine(image.ImageBytes.Length);
            }
            var result = await _imageService.UpdateByIdAsync(id, image.ImageBytes);
            if (!result.Success)
                return BadRequest(result.Message);
            return NoContent();
        }

        public class ImagePut
        {
            public string ImageBytes { get; set; }
        }
    }
}
