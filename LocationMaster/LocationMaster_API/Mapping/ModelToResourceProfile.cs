using AutoMapper;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Resources;

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
