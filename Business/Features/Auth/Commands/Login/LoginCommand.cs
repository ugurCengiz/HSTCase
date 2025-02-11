using Core.Entities.DTOs;
using Core.ResponseTypes;
using Core.Services;
using MediatR;

namespace Business.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<Response<TokenDto>>
    {
        public UserForLoginDto UserForLoginDto { get; set; }


        public class LoginCommandHandler : IRequestHandler<LoginCommand, Response<TokenDto>>
        {
            private readonly IAuthenticationService _authenticationService;

            public LoginCommandHandler(IAuthenticationService authenticationService)
            {
                _authenticationService = authenticationService;
            }

            public async Task<Response<TokenDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                return await _authenticationService.CreateTokenForLoginAsync(request.UserForLoginDto);
            }
        }
    }
}
