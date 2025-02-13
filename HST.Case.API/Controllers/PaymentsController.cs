using Business.Features.Payments.Commands.Process;
using Microsoft.AspNetCore.Mvc;

namespace HST.Case.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentsController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentCommand command)
        {
            var result = await Mediator.Send(command);
            return result ? Ok("Ödeme başarılı.") : BadRequest("Ödeme işlemi başarısız.");
        }
    }
}
