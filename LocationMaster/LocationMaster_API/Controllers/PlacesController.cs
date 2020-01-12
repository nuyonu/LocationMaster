using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationMaster_API.Domain.Services;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Extensions;
using LocationMaster_API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace LocationMaster_API.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{v:apiVersion}/[controller]")]
    public class PlacesController : Controller
    {
        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet("pages")]
        public ActionResult Get(int page = 1, int sizePage = 32, bool descending = false, string orderBy = "category",
            string search = null)
        {
            var response = _placeService.GetPage(page, sizePage, descending, orderBy, search);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IEnumerable<PlaceInfoResource>> GetAll()
        {
            var places = await _placeService.ListAsync();
            return await Task.Run(() => places.Select(place => new PlaceInfoResource(place)).ToList());
        }

        [HttpGet("{id}")]
        public PlaceInfoResponse GetInfoForPlace(Guid id)
        {
            var response = _placeService.GetInfo(id);
            return response;
        }

        [HttpGet("Moderator/{id}")]
        public Response<List<PlaceInfoResource>> GetPlacesOfModerator(Guid id)
        {
            return _placeService.GetPlaceOfModerator(id);
        }


        [HttpPost]
        public IActionResult Post([FromBody] PlaceSave resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            return Created($"/api/v1/places/", _placeService.SaveAsync(resource));
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] PlaceSave value)
        {
            _placeService.Update(value, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _placeService.DeleteAsync(id);
            if (!result)
                return BadRequest();
            return NoContent();
        }


//        private readonly LocationMasterContext _context;
        private readonly IPlaceService _placeService;
//        private readonly PlaceWithImageService _withImageService;
    }
}