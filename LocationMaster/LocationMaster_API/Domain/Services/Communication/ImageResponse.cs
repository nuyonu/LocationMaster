using LocationMaster_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationMaster_API.Domain.Services.Communication
{
    public class ImageResponse : BaseResponse
    {
        public Photo Photo { get; private set; }

        private ImageResponse(bool success, string message, Photo photo) : base(success, message)
        {
            Photo = photo;
        }

        public ImageResponse(Photo photo) : this(true, string.Empty, photo)
        { }

        public ImageResponse(string message) : this(false, message, null)
        { }
    }
}
