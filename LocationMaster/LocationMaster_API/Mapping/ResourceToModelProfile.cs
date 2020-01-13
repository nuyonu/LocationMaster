using AutoMapper;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Resources;

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