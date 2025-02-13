using Business.Features.Campaigns.Commands.Delete;
using Business.Features.Campaigns.Commands.Update;
using Business.Features.Products.Commands.Create;
using Business.Features.Products.Commands.Delete;
using Business.Features.Products.Commands.Update;
using Business.Features.Products.Queries.GetList;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HST.Case.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
       

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand command)
        {
            CreateProductResponse response = await Mediator.Send(command);

            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<UpdateProductResponse>> Update([FromBody] UpdateProductCommand command)
        {
            UpdateProductResponse response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteProductResponse>> Delete([FromRoute] int id)
        {
            DeleteProductCommand command = new() { Id = id };

            DeleteProductResponse response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await Mediator.Send(new GetListProductQuery());

            return Ok(response);
        }
    }
}
