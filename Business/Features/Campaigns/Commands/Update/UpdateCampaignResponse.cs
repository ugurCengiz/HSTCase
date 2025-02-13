using Core.Entities.Concrete;

namespace Business.Features.Campaigns.Commands.Update
{
    public class UpdateCampaignResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int Installment { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Status Status { get; set; }
    }
}
