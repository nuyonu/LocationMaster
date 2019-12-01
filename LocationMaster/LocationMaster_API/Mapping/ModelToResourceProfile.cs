using AutoMapper;
using LocationMaster_API.Models.Entities;
using LocationMaster_API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationMaster_API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
        }
    }
}
