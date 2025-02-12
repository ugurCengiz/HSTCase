using Core.Entities;
namespace Entities.Concrete
{
    public class OrderDetail:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; } // Ürün fiyatı (sipariş sırasında)
    }
}
