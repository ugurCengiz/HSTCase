using Entities.Enums;

namespace Business.Features.Orders.Commands.Update
{
  public  class UpdateOrderResponse
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
