using Business.Servies.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using MediatR;

namespace Business.Features.Orders.Commands.Create
{
    public class CreateOrderCommand : IRequest<int>
    {
        public BasketDto Basket { get; set; }
        public string Email { get; set; }
        public int SelectedInstallment { get; set; }


        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
        {
            private readonly IOrderService _orderService;
            private readonly IBasketService _basketService;
            private readonly ICampainService _campainService;

            public CreateOrderCommandHandler(IOrderService orderService, IBasketService basketService = null, ICampainService campainService = null)
            {
                _orderService = orderService;
                _basketService = basketService;
                _campainService = campainService;
            }

            public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                var availableInstallments = await _campainService.GetAvailableInstallments(request.Basket.TotalPrice);
                if (!availableInstallments.Contains(request.SelectedInstallment))
                {
                    request.SelectedInstallment = 0; 
                }
                var order = new Order
                {
                    Email = request.Email,
                    TotalAmount = request.Basket.TotalPrice,
                    OrderDate = DateTime.UtcNow,
                    Installment= request.SelectedInstallment,
                    Status = Status.Active,
                    OrderDetails = request.Basket.Items.Select(i => new OrderDetail
                    {
                        ProductId = i.ProductId,
                        Quantity = i.Quantity,
                        Price = i.Price
                    }).ToList()
                };

                _orderService.Add(order);
               

                return order.Id;
            }
        }
    }
}
