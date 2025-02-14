using Core.Entities;
using Entities.Enums;

namespace Entities.Concrete
{
    public class Order:BaseEntity
    {
        public string Email { get; set; }
        public decimal TotalAmount { get; set; }
        public int Installment { get; set; }      
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; } =OrderStatus.Received;
        public List<OrderDetail> OrderDetails { get; set; } = new();       

     

    }
}
