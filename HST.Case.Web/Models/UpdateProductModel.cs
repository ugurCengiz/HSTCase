using Core.Entities.Concrete;

namespace HST.Case.Web.Models
{
    public class UpdateProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Status Status { get; set; }

    }
}
