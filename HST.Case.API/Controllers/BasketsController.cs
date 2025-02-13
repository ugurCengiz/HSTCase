
using Business.Features.Baskets.Commands.Create;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HST.Case.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketsController : CustomBaseController
    {
        [HttpPost()]
        public async Task<IActionResult> AddToBasket([FromBody] AddToBasketCommand command)
        {
            bool response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetBasket(string email)
        {
            var basket = await Mediator.Send(new Basket { Email = email });
            return basket != null ? Ok(basket) : NotFound("Sepet bulunamadı.");
        }

    }
}
