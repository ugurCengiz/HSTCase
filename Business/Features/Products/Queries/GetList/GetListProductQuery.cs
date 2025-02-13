using Business.Servies.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Features.Products.Queries.GetList
{
    public class GetListProductQuery : IRequest<List<Product>>
    {


        public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, List<Product>>
        {
            private readonly IProductService _productService;

            public GetListProductQueryHandler(IProductService productService)
            {
                _productService = productService;
            }

            public async Task<List<Product>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
            {
                return await _productService.GetListAsync(x => !x.IsDeleted);

            }
        }
    }
}
