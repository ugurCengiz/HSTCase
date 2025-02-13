using Business.MQ.Events;
using MassTransit;

namespace Business.MQ.Producers
{
   public class OrderCreatedProcuder
    {

        private readonly ISendEndpointProvider _sendEndpointProvider;

        public OrderCreatedProcuder(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task SendOrderForProcessing(OrderCreatedEvent orderCreatedEvent)
        {
            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:order-created-queue"));

            await sendEndpoint.Send(orderCreatedEvent);
        }
    }
}
