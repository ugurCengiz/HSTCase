using Entities.Enums;

namespace HST.Case.Web.Models
{
    public class UpdateOrderModel
    {
        public int Id { get; set; }      
        public OrderStatus Status { get; set; }
    }
}
