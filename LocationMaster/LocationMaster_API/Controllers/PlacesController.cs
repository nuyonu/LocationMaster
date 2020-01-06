using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using LocationMaster_API.Domain;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Services;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Domain.UnitOfWork;
using LocationMaster_API.Extensions;
using LocationMaster_API.Resources;
using LocationMaster_API.Services;
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
        public async Task<IActionResult> Post([FromBody] PlaceSave resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            return Created($"/api/v1/places/", _placeService.SaveAsync(resource));
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] PlaceSave value)
        {
            _placeService.Update(value, id);
//            var unitOfWork = new UnitOfWork(_context);
//            var user = unitOfWork.Users.Find(s => s.Username == "moderator").First();
//            var cat = Category.Create("cat2");
//            unitOfWork.Category.Add(cat);
//            for (var i = 0; i < 1000; i++)
//                unitOfWork.Locations.Add(Place.Create(user, "loc" + i.ToString(), "dasd" + i.ToString(), cat, 12 + i,
//                    "89 West 86th Transverse Road, New York, NY 10024 New York, Central Park New York, Manhattan New York United States",
//                    40.785091, -73.968285));
//            unitOfWork.Complete();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _placeService.DeleteAsync(id);
            if (!result)
                return BadRequest();
            return NoContent();
        }


        private readonly IMapper _mapper;
        private readonly ILogger<PlacesController> _logger;
        private readonly LocationMasterContext _context;
        private readonly IPlaceService _placeService;
        private readonly PlaceWithImageService _withImageService;
    }
}