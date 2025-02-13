using Business.Servies.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Orders.Queries.GetById
{
    public class GetByIdOrderQuery : IRequest<Order>
    {
        public int OrderId { get; set; }

        public class GetOrderQueryHandler : IRequestHandler<GetByIdOrderQuery, Order>
        {
            private readonly IOrderService _orderService;

            public GetOrderQueryHandler(IOrderService orderService)
            {
                _orderService = orderService;
            }

            public async Task<Order> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
            {
                return await _orderService.GetAsync(x => x.Id == request.OrderId, include: query => query.Include(x => x.OrderDetails).ThenInclude(x => x.Product));
            }
        }
    }
}
