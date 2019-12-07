using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LocationMaster_API.Domain;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Services;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Domain.UnitOfWork;
using LocationMaster_API.Extensions;
using LocationMaster_API.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocationMaster_API.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{v:apiVersion}/[controller]")]
    public class PlacesController : Controller
    {
        public PlacesController(IMapper mapper, ILogger<PlacesController> logger, LocationMasterContext context,
            IPlaceService placeService)
        {
            _placeService = placeService;
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("pages")]
        public ActionResult Get(int page = 1, int sizePage = 10, bool descending = false, string orderBy = "category",
            string search = null)
        {
            var response = _placeService.GetPage(page, sizePage, descending, orderBy, search);
            if (!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

//todo transform to view
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


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SavePlaceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var unitOfWork = new UnitOfWork(_context);
            var user = await unitOfWork.Users.FindByIdAsync(resource.OwnerId);
            if (user == null)
                return BadRequest("Owner not found");
            var location = Place.Create(user, resource.Name, resource.Description, null, resource.TicketPrice);
            var result = await _placeService.SaveAsync(location);
            if (!result.Success)
                return BadRequest(result.Message);
            return Created($"/api/v1/places/{location.PlaceId}", resource);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var resullt = await _placeService.DeleteAsync(id);
            if (!resullt.Success)
                return BadRequest(resullt.Message);
            return NoContent();
        }


        private readonly IMapper _mapper;
        private readonly ILogger<PlacesController> _logger;
        private readonly LocationMasterContext _context;
        private readonly IPlaceService _placeService;
    }
}