using Business.Servies.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Baskets.Queries
{
    public class GetByBasketWithEmailQuery : IRequest<Basket>
    {
        public string Email { get; set; }

        public class GetBasketQueryHandler : IRequestHandler<GetByBasketWithEmailQuery, Basket>
        {
            private readonly IBasketService _basketService;

            public GetBasketQueryHandler(IBasketService basketService)
            {
                _basketService = basketService;
            }

            public async Task<Basket> Handle(GetByBasketWithEmailQuery request, CancellationToken cancellationToken)
            {
                return await _basketService.GetAsync(x => x.Email == request.Email, include: query => query.Include(x => x.Items).ThenInclude(x => x.Product));

            }
        }
    }
}
