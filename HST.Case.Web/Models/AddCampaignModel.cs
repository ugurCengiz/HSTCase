namespace HST.Case.Web.Models
{
    public class AddCampaignModel
    {
        public string Name { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int Installment { get; set; }
    }
}
