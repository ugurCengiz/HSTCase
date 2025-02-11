using Core.Entities.Concrete;
using Core.Entities.DTOs;

namespace Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser appUser);
    }
}
