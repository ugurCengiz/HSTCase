using AutoMapper;
using Business.Features.Campaigns.Commands.Create;
using Business.Features.Campaigns.Commands.Delete;
using Business.Features.Campaigns.Commands.Update;
using Business.Features.Orders.Commands.Update;
using Business.Features.Orders.Queries.GetList;
using Business.Features.Products.Commands.Create;
using Business.Features.Products.Commands.Delete;
using Business.Features.Products.Commands.Update;
using Business.Features.Users.Commands.Update;
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

            CreateMap<UpdateUserCommand, AppUser>().ReverseMap();
            CreateMap<AppUser, UpdateUserResponse>().ReverseMap();
            CreateMap<AppUser, UpdateAppUserDto>().ReverseMap();

            CreateMap<GetListOrderQuery, Order>().ReverseMap();
            CreateMap<Order,GetListOrderDto >().ReverseMap();
            CreateMap<UpdateOrderCommand, Order>().ReverseMap();
            CreateMap<Order, UpdateOrderResponse>().ReverseMap();






        }
    }
}
