using AutoMapper;
using LocationMaster_API.Resources;
using LocationMaster_API.Domain.Entities;

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
