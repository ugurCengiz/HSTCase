namespace HST.Case.Web.Models
{
    public class BasketModel
    {
        public string Email { get; set; }
        public List<BasketItemModel> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    }
}
