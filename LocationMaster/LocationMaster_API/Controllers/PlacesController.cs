using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LocationMaster_API.Domain;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.UnitOfWork;
using LocationMaster_API.Services;
using LocationMaster_API.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocationMaster_API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        public PlacesController(IMapper mapper, ILogger<PlacesController> logger, LocationMasterContext context,
            IPlaceService placeService)
        {
            _placeService = placeService;
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("/pages")]
        public ActionResult Get(int page=1, int sizePage = 10, bool descending = false, string orderBy = "category",
            string search = null)
        {
            Console.Write("here");
            if (page < 1)
                return BadRequest("1");

            var service=new PlacesService(_context);
//            var result = service.GetPage(page, sizePage, descending, o
            var unit=new UnitOfWork(_context);
            var result = unit.Locations.GetPage(page, sizePage, false, " ", s => s.Attractions);
//            if (page > result.PageCount)
//                return BadRequest("2");
            return Ok(result);
        }

//        [HttpGet("{}")]

        [HttpGet]
        public async Task<IEnumerable<Place>> GetAll()
        {
            return await _placeService.ListAsync();
        }

/*        // GET api/values/5
        [HttpPost]
        public ActionResult Get()
        {
            var unitOfWork = new UnitOfWork(_context);
            var u = unitOfWork.Users.Find(e => e.Username == "use2r").First();
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Locations.Add(Place.Create(u, "hete", "sdad", Category.Create("das"), 12.0f));
            unitOfWork.Complete();
            return Ok("dsa");
        }*/

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private readonly IMapper _mapper;
        private readonly ILogger<PlacesController> _logger;
        private readonly LocationMasterContext _context;
        private readonly IPlaceService _placeService;
    }
}