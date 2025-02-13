namespace HST.Case.Web.Models
{
    public class CheckoutViewModel
    {
        public decimal TotalAmount { get; set; }
        public List<int> AvailableInstallments { get; set; }
    }

}
