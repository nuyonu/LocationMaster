using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LocationMaster_API.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{v:apiVersion}/[controller]")]
    public class ProxyCorsController : Controller
    {
        [HttpGet]
        public async Task<string> Cors(string input)
        {
            return await _client.GetStringAsync(
                $"{PlaceAutocomplete}?input={input}&type=address&key={Key}");
        }

        [HttpGet("Geo")]
        public async Task<string> CorsGeo(string input)
        {
            return await _client.GetStringAsync(
                $"https://maps.googleapis.com/maps/api/geocode/json?address={input}&type=address&key={Key}");
        }

        public ProxyCorsController(HttpClient client)
        {
            _client = client;
        }

        private HttpClient _client;
        private const string Key = "AIzaSyCi4urwHsvNARToGpCz32RSigv_vT8hbuo";
        private const string GeoCodeUrl = "https://maps.googleapis.com/maps/api/geocode/json";
        private const string CorsProxy = "https://cors-anywhere.herokuapp.com/";
        private const string PlaceAutocomplete = "https://maps.googleapis.com/maps/api/place/autocomplete/json";

    }
}