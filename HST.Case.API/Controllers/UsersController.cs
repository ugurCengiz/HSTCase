using Business.Features.Users.Commands.Update;
using Business.Features.Users.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace HST.Case.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : CustomBaseController
    {


        [HttpPut]
        public async Task<ActionResult<UpdateUserResponse>> Update([FromBody] UpdateUserCommand command)
        {
            UpdateUserResponse response = await Mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await Mediator.Send(new GetListUserQuery());

            return Ok(response);
        }
    }
}
