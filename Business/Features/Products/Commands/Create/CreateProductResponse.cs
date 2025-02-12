namespace Business.Features.Products.Commands.Create
{
   public class CreateProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
