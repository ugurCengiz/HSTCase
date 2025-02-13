namespace HST.Case.Web.Models
{
    public class PaymentViewModel
    {
        public int Installment { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string CardNumber { get; set; }
        public string ExpDate { get; set; }
        public string CVV { get; set; }
    }
}
