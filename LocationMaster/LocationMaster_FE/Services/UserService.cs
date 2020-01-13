using System;
using System.Net.Http;
using System.Threading.Tasks;
using LocationMaster_FE.Models;
using Microsoft.AspNetCore.Components;

namespace LocationMaster_FE.Services
{
    public class UserService
    {
        public async Task<UserResponse> GetUserById(Guid id)
        {
            return await _httpClient.GetJsonAsync<UserResponse>(BaseUrl + Port + $"/api/v1/Users/{id}");
        }
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            BaseUrl = "https://localhost:";
            Port = "5001";
        }
        private string BaseUrl { get; set; }
        private string Port { get; set; }
        private HttpClient _httpClient;
    }
}