using Core.Entities.DTOs;
using Core.ResponseTypes;
using Core.Services;
using MediatR;

namespace Business.Features.Auth.Commands.Register
{
    public class RegisterForAdminCommand : IRequest<Response<AppUserDto>>
    {
        public CreateUserDto CreateUserDto { get; set; }


        public class RegisterForAdminCommandHandler : IRequestHandler<RegisterForAdminCommand, Response<AppUserDto>>
        {
            private readonly IAuthenticationService _authenticationService;

            public RegisterForAdminCommandHandler(IAuthenticationService authenticationService)
            {
                _authenticationService = authenticationService;
            }

            public async Task<Response<AppUserDto>> Handle(RegisterForAdminCommand request, CancellationToken cancellationToken)
            {
                return await _authenticationService.RegisterForAdminAsync(request.CreateUserDto);
            }
        }
    }
}
