using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationMaster_FE.Services.IServices
{
    public interface IImageService
    {
        Task<string> GetImageSrc(Guid id);
    }
}
