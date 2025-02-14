using Business.Mappings;
using Business.Servies.Abstract;
using Business.Servies.Concrete;
using Entities.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Orders.Queries.GetList
{
    public class GetListOrderQuery : IRequest<List<GetListOrderDto>>
    {


        public class GetListOrderQueryHandler : IRequestHandler<GetListOrderQuery, List<GetListOrderDto>>
        {
            private readonly IOrderService _orderService;

            public GetListOrderQueryHandler(IOrderService orderService)
            {
                _orderService = orderService;
            }

            public async Task<List<GetListOrderDto>> Handle(GetListOrderQuery request, CancellationToken cancellationToken)
            {
                List<Order> orders = await _orderService.GetListAsync();

                List<GetListOrderDto> response = ObjectMapper.Mapper.Map<List<GetListOrderDto>>(orders);
                return response;
            }
        }
    }
}
