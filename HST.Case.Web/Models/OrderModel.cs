namespace HST.Case.Web.Models
{
    public class OrderModel
    {
        public BasketModel Basket { get; set; }
        public string Email { get; set; }
        public int selectedInstallment { get; set; }
    }
}
