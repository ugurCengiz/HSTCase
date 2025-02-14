using Business.Mappings;
using Business.Servies.Abstract;
using Entities.Concrete;
using Entities.Enums;
using MediatR;

namespace Business.Features.Orders.Commands.Update
{
    public class UpdateOrderCommand : IRequest<UpdateOrderResponse>
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }

        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderResponse>
        {
            private readonly IOrderService _orderService;

            public UpdateOrderCommandHandler(IOrderService orderService)
            {
                _orderService = orderService;
            }

            public async Task<UpdateOrderResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            {
                Order order = await _orderService.GetAsync(x => x.Id == request.Id);
                order = ObjectMapper.Mapper.Map(request, order);
                _orderService.Update(order);

                UpdateOrderResponse response = ObjectMapper.Mapper.Map<UpdateOrderResponse>(order);
                return response;
            }
        }
    }
}
