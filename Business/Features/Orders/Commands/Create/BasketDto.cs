namespace Business.Features.Orders.Commands.Create
{
    public class BasketDto
    {
        public string Email { get; set; }
        public List<BasketItemDto> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    }
}
