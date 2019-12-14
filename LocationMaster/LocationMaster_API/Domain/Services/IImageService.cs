using LocationMaster_API.Domain.Services.Communication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationMaster_API.Domain.Services
{
    public interface IImageService
    {
        Task<byte[]> GetFileByPath(string path);
        Task<string> GetPathById(Guid id);
        Task<ImageResponse> UpdateByIdAsync(Guid id, string image);
    }
}
