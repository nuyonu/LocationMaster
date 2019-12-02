using AutoMapper;
using LocationMaster_API.Resources;
using LocationMaster_API.Domain.Entities;

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