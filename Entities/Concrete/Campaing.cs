using Core.Entities;

namespace Entities.Concrete
{
    public class Campaing:BaseEntity
    {
        public string CampaingName { get; set; }
        public int Price { get; set; }
        public int Installment { get; set; }



    }
}
