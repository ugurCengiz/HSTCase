using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Status Status { get; set; }


    }
}
