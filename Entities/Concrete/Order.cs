using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Order:BaseEntity
    {
        public string Email { get; set; }
        public decimal TotalAmount { get; set; }
        public int Installment { get; set; }      
        public DateTime OrderDate { get; set; }         
        public Status Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new();       

     

    }
}
