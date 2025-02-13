using Business.MQ.Producers;
using Business.Servies.Abstract;
using Entities.Concrete;
using MediatR;

namespace Business.Features.Payments.Commands.Process
{
    public class ProcessPaymentCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string CardNumber { get; set; }
        public string ExpDate { get; set; }
        public string CVV { get; set; }


        public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand, bool>
        {
            private readonly IPaymentService _paymentService;
            private readonly IOrderService _orderService;
            private readonly OrderCreatedProcuder _procuder;

            public ProcessPaymentCommandHandler(IPaymentService paymentService, IOrderService orderService, OrderCreatedProcuder procuder)
            {
                _paymentService = paymentService;
                _orderService = orderService;
                _procuder = procuder;
            }

            public async Task<bool> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
            {
                var order = await _orderService.GetAsync(x => x.Id == request.OrderId);

                try
                {
                    if (order == null)
                    {
                        return false;

                    }

                    var payment = new Payment
                    {
                        OrderId = request.OrderId,
                        Name = request.Name,
                        SurName = request.SurName,
                        CardNumber = SHA512ForString(request.CardNumber),
                        ExpDate = SHA512ForString(request.ExpDate),
                        CVV = SHA512ForString(request.CVV)
                    };

                    _paymentService.Add(payment);

                    await _procuder.SendOrderForProcessing(new MQ.Events.OrderCreatedEvent
                    {
                        Subject = "Siparişiniz oluşturuldu",
                        Body = $"Sevgili {payment.Name} siparişiniz {order.CreatedDate} başarıyla oluşturulmuştur.",
                        Email = order.Email
                    });
                    return true;
                }
                catch (Exception)
                {

                    await _procuder.SendOrderForProcessing(new MQ.Events.OrderCreatedEvent
                    {
                        Subject = "Siparişiniz oluşturulamadı",
                        Body = $"Sevgili {request.Name} siparişiniz {order.CreatedDate} oluşturulamamıştır.",
                        Email = order.Email
                    });

                    throw;
                }

            }

            public string SHA512ForString(string input)
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(input);
                using (var hash = System.Security.Cryptography.SHA512.Create())
                {
                    var hashedInputBytes = hash.ComputeHash(bytes);                   
                    var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                    foreach (var b in hashedInputBytes)
                        hashedInputStringBuilder.Append(b.ToString("X2"));
                    return hashedInputStringBuilder.ToString();
                }
            }


        }
    }
}
