namespace Business.MQ.Events
{
    public class OrderCreatedEvent
    {
        public string Email { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    


    }
}
