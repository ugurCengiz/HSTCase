using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Campaing:BaseEntity
    {
        public string Name { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int Installment { get; set; }
        public Status Status { get; set; }



    }
}
