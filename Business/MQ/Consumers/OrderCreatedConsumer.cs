using Business.MQ.Events;
using MailKit.Net.Smtp;
using MassTransit;
using MimeKit;

namespace Business.MQ.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            try
            {
                var message = context.Message;

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Hst", "davon.christiansen@ethereal.email"));
                email.To.Add(new MailboxAddress("", "davon.christiansen@ethereal.email"));
                email.Subject = message.Subject;
                var body = message.Body;

                email.Body = new TextPart("html") { Text = body };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.ethereal.email", 587, false);
                await smtp.AuthenticateAsync("davon.christiansen@ethereal.email", "478UkmF56mdFrvvbFu");
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
