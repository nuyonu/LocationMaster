using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using LocationMaster_FE.ContainerState;
using LocationMaster_FE.Models;
using LocationMaster_FE.Models.Responses;

namespace LocationMaster_FE.Services
{
    public class PlaceService
    {
        private string BaseUrl { get; set; }
        private string Port { get; set; }
        private HttpClient _httpClient;
        private SearchStorage _storage;

        public async Task<PlacesResponse> GetInitialPage()
        {
            return await _httpClient.GetJsonAsync<PlacesResponse>(BaseUrl + Port + "/api/v1.0/Places/pages");
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _httpClient.DeleteAsync(BaseUrl + Port + $"/api/v1.0/Places/{id}");
            Console.WriteLine(result.StatusCode);
            return result.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<Response<List<PlaceInfoResource>>> GetPlacesOfModerator(Guid id)
        {
            return await _httpClient.GetJsonAsync<Response<List<PlaceInfoResource>>>(
                BaseUrl + Port + $"/api/v1.0/Places/Moderator/{id}");
        }

        public async Task<PlacesResponse> GetPage(int page)
        {
            if (_storage.Search == null)
                return await _httpClient.GetJsonAsync<PlacesResponse>(
                    BaseUrl + Port + "/api/v1.0/Places/pages?page=" + page.ToString());
            else
                return await _httpClient.GetJsonAsync<PlacesResponse>(
                    BaseUrl + Port + "/api/v1.0/Places/pages?page=" + page.ToString() + "&search=" + _storage.Search);
        }

        public async Task PostPlace(PlaceSave placeSave)
        {
            await _httpClient.PostJsonAsync(BaseUrl + Port + "/api/v1.0/Places", placeSave);
        }

        public async Task<Response<PlaceInfoResource>> GetPlace(Guid id)
        {
            return await _httpClient.GetJsonAsync<Response<PlaceInfoResource>>(BaseUrl + Port + $"/api/v1.0/Places/{id}");
        }

        public async Task<Response<IEnumerable<PlaceInfoResource>>> GetPlacesByPrice(int count, bool ascending)
        {
            return await _httpClient.GetJsonAsync<Response<IEnumerable<PlaceInfoResource>>>(BaseUrl + Port + $"/api/v1.0/Places/PlacesByPrice/{count}/{ascending}");
        }

        public PlaceService(HttpClient httpClient, SearchStorage storage)
        {
            _storage = storage;
            _httpClient = httpClient;
            BaseUrl = "https://localhost:";
            Port = "5001";
        }

        public async Task Put(PlaceSave placeSave,string id)
        {
            await _httpClient.PutJsonAsync(BaseUrl + Port + $"/api/v1.0/Places/{id}", placeSave);
        }

        public async Task<Response<Dictionary<string, byte[]>>> GetImagesOfPlace(string id)
        {
            return await _httpClient.GetJsonAsync<Response<Dictionary<string, byte[]>>>(
                BaseUrl + Port + $"/api/v1.0/Images/Places/{id}");
        }
//        public async Task Put(PlaceSave)
    }
}