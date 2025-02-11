using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.DTOs;

namespace Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<AppUser, AppUserDto>().ReverseMap();
        }
    }
}
