using Core.ResponseTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HST.Case.API.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        protected IMediator Mediator =>
       _mediator ??=
           HttpContext.RequestServices.GetService<IMediator>()
           ?? throw new InvalidOperationException("IMediator cannot be retrieved from request services.");

        private IMediator? _mediator;

        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
