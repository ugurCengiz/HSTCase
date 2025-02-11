using Core.Entities;

namespace Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
      
    }
}
