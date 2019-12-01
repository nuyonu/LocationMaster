using AutoMapper;
using LocationMaster_API.Models.Entities;
using LocationMaster_API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationMaster_API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
        }
    }
}
