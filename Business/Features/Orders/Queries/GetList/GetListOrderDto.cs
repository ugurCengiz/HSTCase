using Entities.Concrete;
using Entities.Enums;

namespace Business.Features.Orders.Queries.GetList
{
  public  class GetListOrderDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public decimal TotalAmount { get; set; }
        public int Installment { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; } 
     
    }
}
