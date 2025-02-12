using AutoMapper;
using Business.Mappings;
using Business.Servies.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Features.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
        {
            private readonly IProductService _productService;

            public CreateProductCommandHandler(IProductService productService)
            {
                _productService = productService;

            }

            public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                Product product = ObjectMapper.Mapper.Map<Product>(request);

                _productService.Add(product);
                await Task.CompletedTask;

                CreateProductResponse response = ObjectMapper.Mapper.Map<CreateProductResponse>(product);

                return response;
            }
        }
    }
}
