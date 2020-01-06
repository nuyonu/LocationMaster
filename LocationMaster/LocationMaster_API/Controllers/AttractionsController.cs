using System;
using System.Collections.Generic;
using System.Text.Json;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Resources;
using LocationMaster_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocationMaster_API.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{v:apiVersion}/[controller]")]
    public class AttractionsController : Controller
    {
        [HttpGet("{id}")]
        public Response<IEnumerable<AttractionsResource>> GetAllForAPlace(Guid id, bool image = false)
        {
            return new Response<IEnumerable<AttractionsResource>>(_service.GetAttractionsForPlace(id, image));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (_service.Delete(id))
                return NoContent();
            return BadRequest("Attraction not found");
        }

        [HttpPost("{id}")]
        public IActionResult PostAttraction(Guid id, [FromBody] SaveAttractionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is not valid");
            return Created("Success", _service.SaveAttraction(id, resource));
        }

        [HttpPut]
        public IActionResult PutAttraction([FromBody] UpdateAttractionRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is not valid");
            var result = _service.Update(request);
            if (!result.Success)
                return BadRequest("Fail to update attraction");
            Console.WriteLine(JsonSerializer.Serialize(result));
            return Ok();
        }

        public AttractionsController(AttractionsService service)
        {
            _service = service;
        }

        private readonly AttractionsService _service;
    }
}