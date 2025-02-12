using Core.Entities;

namespace Entities.Concrete
{
    public class Basket:BaseEntity
    {
        public string Email { get; set; }
        public List<BasketItem> Items { get; set; } = new();
        public decimal TotalPrice
        {
            get => Items.Sum(x => x.Price * x.Quantity);
        }
    }
}
