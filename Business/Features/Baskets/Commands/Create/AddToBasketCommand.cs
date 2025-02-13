using Business.Servies.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Baskets.Commands.Create
{
    public class AddToBasketCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public List<BasketItem> BasketItems { get; set; }


        public class AddToBasketCommandHandler : IRequestHandler<AddToBasketCommand, bool>
        {
            private readonly IBasketService _basketService;
            private readonly IProductService _productService;
            private readonly IBasketItemService _basketItemService;


            public AddToBasketCommandHandler(IBasketService basketService, IProductService productService = null, IBasketItemService basketItemService = null)
            {
                _basketService = basketService;
                _productService = productService;
                _basketItemService = basketItemService;
            }

            public async Task<bool> Handle(AddToBasketCommand request, CancellationToken cancellationToken)
            {

              

                return true;
            }
        }
    }


}
