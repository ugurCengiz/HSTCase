namespace Entities.Concrete
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ExpDate { get; set; }
        public int CVV { get; set; }

    }
}
