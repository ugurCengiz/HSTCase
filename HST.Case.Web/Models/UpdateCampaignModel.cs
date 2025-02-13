using Core.Entities.Concrete;

namespace HST.Case.Web.Models
{
    public class UpdateCampaignModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int Installment { get; set; }
        public Status Status { get; set; }
    }
}
