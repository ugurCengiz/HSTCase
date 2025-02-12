using AutoMapper;
using Business.Features.Products.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HST.Case.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductResponse>> Add([FromBody] CreateProductCommand command)
        {
            CreateProductResponse response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
