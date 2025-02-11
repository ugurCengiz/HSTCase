using Core.Entities.DTOs;
using Core.ResponseTypes;

namespace Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateTokenForLoginAsync(UserForLoginDto userForLoginDto);

        Task<Response<AppUserDto>> RegisterForUserAsync(CreateUserDto createUserDto);

        Task<Response<AppUserDto>> RegisterForAdminAsync(CreateUserDto createUserDto);

        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);

        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);
    }
}
