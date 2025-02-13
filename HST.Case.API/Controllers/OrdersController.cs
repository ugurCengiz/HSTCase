using Business.Features.Orders.Commands.Create;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HST.Case.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var orderId = await Mediator.Send(command);
            return orderId > 0 ? Ok(new { OrderId = orderId }) : BadRequest("Sipariş oluşturulamadı.");
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await Mediator.Send(new Order { Id = id });
            return order != null ? Ok(order) : NotFound("Sipariş bulunamadı.");
        }

       
    }
}
