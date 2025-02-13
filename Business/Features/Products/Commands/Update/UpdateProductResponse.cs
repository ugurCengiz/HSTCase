using Core.Entities.Concrete;

namespace Business.Features.Products.Commands.Update
{
   public class UpdateProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Status Status { get; set; }
    }
}
