using System;
using System.Collections.Generic;
using System.Linq;
using LocationMaster_API.Domain;
using LocationMaster_API.Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocationMaster_API.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, LocationMasterContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            using var unitOfWork = new UnitOfWork(_context);
            unitOfWork.Users.Add(LocationMaster_API.Domain.Entities.User.Create("nuyonu", "parola", "ceva@gmail.com", "firstName", "LastName"));
            unitOfWork.Complete();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }

        private readonly LocationMasterContext _context;
    }
}