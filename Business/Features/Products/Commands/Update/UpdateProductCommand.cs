using Business.Features.Campaigns.Commands.Update;
using Business.Mappings;
using Business.Servies.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using MediatR;

namespace Business.Features.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<UpdateProductResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Status Status { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductResponse>
        {
            private readonly IProductService _productService;

            public UpdateProductCommandHandler(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                Product product = await _productService.GetAsync(x => x.Id == request.Id);
                product = ObjectMapper.Mapper.Map(request, product);
                _productService.Update(product);

                UpdateProductResponse response = ObjectMapper.Mapper.Map<UpdateProductResponse>(product);
                return response;


            }
        }
    }
}
