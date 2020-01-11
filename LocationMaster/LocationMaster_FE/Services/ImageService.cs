using LocationMaster_FE.Services.IServices;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using LocationMaster_FE.Helpers;
using Newtonsoft.Json;

namespace LocationMaster_FE.Services
{
    public class ImageService : IImageService
    {
        private HttpClient http;

        public ImageService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<string> GetImageSrc(Guid id)
        {
            var response = await http.GetAsync(AppConfig.BaseUrl + AppConfig.Port + "/api/v1.0/images/" + id);
            response.EnsureSuccessStatusCode();
            string responseString = await response.Content.ReadAsStringAsync();
            string imageStringBytes = responseString.Substring(1, responseString.Length - 2);
            string mimeType = "image/webp";
            string imageSrc = string.Format("data:{0};base64,{1}", mimeType, imageStringBytes);
            return imageSrc;
        }
    }
}
