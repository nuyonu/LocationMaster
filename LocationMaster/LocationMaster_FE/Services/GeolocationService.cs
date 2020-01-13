using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LocationMaster_FE.Services.IServices;
using Newtonsoft.Json.Linq;

namespace LocationMaster_FE.Services
{
    public class GeolocationService : IGeolocationService
    {
        public GeolocationService(HttpClient httpClient, UrlStorageService url)
        {
            _httpClient = httpClient;
            PlaceAutocomplete = url.PlaceAutocomplete;
            GeoCodeUrl = url.GeoCodeUrl;
            Key = url.KeyAutocomplet;
        }

        public async Task<string> GetLocation(Dictionary<string, double> response)
        {
            var result = await _httpClient.GetStringAsync(
                $"{GeoCodeUrl}?latlng=40.785091,-73.968285&key={Key}");
            var json = JObject.Parse(result);
            var jArray = (JArray) json["results"];
            return (string) jArray[0]["formatted_address"];
        }

        public async Task<List<string>> GetPredictions(string input)
        {
            var result =
                await _httpClient.GetStringAsync(
                    $"{PlaceAutocomplete}?input={input}");
            var json = JObject.Parse(result);
            var jArray = (JArray) json["predictions"];
            return jArray.Select(place => (string) place["description"]).ToList();
        }

        public async Task<List<double>> GetCoordonate(string input)
        {
            var result = await _httpClient.GetStringAsync($"{GeoCodeUrl}?input={input}&key={Key}");
            var json = JObject.Parse(result);
            var jArray = (JArray) json["results"];
            var detail = jArray[0]["geometry"]["location"];
            return new List<double>() {(double) detail["lat"], (double) detail["lng"]};
        }

        private HttpClient _httpClient;
        private readonly string Key;
        private readonly string GeoCodeUrl;
        private readonly string PlaceAutocomplete;
    }
}