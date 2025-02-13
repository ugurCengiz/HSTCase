using Business.Features.Campaigns.Commands.Create;
using Business.Features.Campaigns.Commands.Delete;
using Business.Features.Campaigns.Commands.Update;
using Business.Features.Campaigns.Queries.GetList;
using Business.Features.Orders.Queries.GetAvailableInstallments;
using Microsoft.AspNetCore.Mvc;

namespace HST.Case.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CampaingsController : CustomBaseController
    {
        [HttpGet("{totalAmount}")]
        public async Task<IActionResult> GetAvailableInstallments([FromRoute] decimal totalAmount)
        {

            var response = await Mediator.Send(new GetAvailableInstallmentsQuery { TotalAmount = totalAmount });

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await Mediator.Send(new GetListCampaignQueries());

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCampaignCommand command)
        {
            CreateCampaignResponse response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateCampaignResponse>> Update([FromBody] UpdateCampaignCommand command)
        {
            UpdateCampaignResponse response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCampaignResponse>> Delete([FromRoute] int id)
        {
            DeleteCampaignCommand command = new() { Id = id };

            DeleteCampaignResponse response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
