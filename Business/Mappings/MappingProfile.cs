using AutoMapper;
using Business.Features.Baskets.Queries;
using Business.Features.Campaigns.Commands.Create;
using Business.Features.Campaigns.Commands.Delete;
using Business.Features.Campaigns.Commands.Update;
using Business.Features.Products.Commands.Create;
using Business.Features.Products.Commands.Delete;
using Business.Features.Products.Commands.Update;
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

            CreateMap<GetByBasketWithEmailQuery, Basket>().ReverseMap();

            CreateMap<CreateCampaignCommand, Campaing>().ReverseMap();
            CreateMap<Campaing, CreateCampaignResponse>().ReverseMap();
            CreateMap<UpdateCampaignCommand, Campaing>().ReverseMap();
            CreateMap<Campaing, UpdateCampaignResponse>().ReverseMap();
            CreateMap<DeleteCampaignCommand, Campaing>().ReverseMap();
            CreateMap<Campaing, DeleteCampaignResponse>().ReverseMap();

            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<Product, CreateProductResponse>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>().ReverseMap();
            CreateMap<Product, UpdateProductResponse>().ReverseMap();
            CreateMap<DeleteProductCommand, Product>().ReverseMap();
            CreateMap<Product, DeleteProductResponse>().ReverseMap();





        }
    }
}
