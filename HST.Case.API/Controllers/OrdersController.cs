using Business.Features.Orders.Commands.Create;
using Business.Features.Orders.Commands.Update;
using Business.Features.Orders.Queries.GetList;
using Business.Features.Products.Commands.Update;
using Business.Features.Products.Queries.GetList;
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
        [HttpPut]
        public async Task<ActionResult<UpdateOrderResponse>> Update([FromBody] UpdateOrderCommand command)
        {
            UpdateOrderResponse response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await Mediator.Send(new Order { Id = id });
            return order != null ? Ok(order) : NotFound("Sipariş bulunamadı.");
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await Mediator.Send(new GetListOrderQuery());

            return Ok(response);
        }
    }
}
