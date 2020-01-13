using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LocationMaster_FE.Models;
using LocationMaster_FE.Models.Responses;
using LocationMaster_FE.Services.IServices;
using Microsoft.AspNetCore.Components;

namespace LocationMaster_FE.Services
{
    public class AttractionsService : IAttractionsService
    {
        public Task delete(Guid id)
        {
            return _httpClient.DeleteAsync(BaseUrl + Port + $"/api/v1.0/Attractions/{id}");
        }

        public bool Save(Guid id, SaveAttractionResource resource)
        {
            Console.WriteLine(id);
            _httpClient.PostJsonAsync(BaseUrl + Port + $"/api/v1.0/Attractions/{id}", resource);
            return true;
        }

        public async Task<Response<List<AttractionResponse>>> Get(Guid id)
        {
            return await _httpClient.GetJsonAsync<Response<List<AttractionResponse>>>(
                BaseUrl + Port + $"/api/v1.0/Attractions/{id}");
        }

        public async Task<Response<List<AttractionResponse>>> GetImages(Guid id)
        {
            return await _httpClient.GetJsonAsync<Response<List<AttractionResponse>>>(
                BaseUrl + Port + $"/api/v1.0/Attractions/{id}?image=true");
        }

        public async Task Put(UpdateAttractionRequest request)
        {
            await _httpClient.PutJsonAsync(BaseUrl + Port + $"/api/v1.0/Attractions", request);
        }

        public AttractionsService(HttpClient httpClient, UrlStorageService url)
        {
            BaseUrl = url.BaseUrl;
            Port = url.Port;
            _httpClient = httpClient;
        }

        private HttpClient _httpClient;
        private string BaseUrl { get; set; }
        private string Port { get; set; }
    }
}