using Business.Features.Campaigns.Commands.Delete;
using Business.Mappings;
using Business.Servies.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Features.Products.Commands.Delete
{
    public class DeleteProductCommand : IRequest<DeleteProductResponse>
    {
        public int Id { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
        {
            private readonly IProductService _productService;

            public DeleteProductCommandHandler(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                Product product = await _productService.GetAsync(x => x.Id == request.Id);
                _productService.Delete(product);

                DeleteProductResponse response = ObjectMapper.Mapper.Map<DeleteProductResponse>(product);
                return response;


            }
        }
    }
}
