using AutoMapper;
using Business.Features.Products.Commands.Create;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Entities.Concrete;

namespace Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<AppUser, AppUserDto>().ReverseMap();

            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<Product, CreateProductResponse>().ReverseMap();
        }
    }
}
