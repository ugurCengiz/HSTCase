using Core.Entities.DTOs;
using Core.ResponseTypes;

namespace Business.Servies.Abstract
{
    public interface IUserService
    {
        Task<Response<IEnumerable<AppUserDto>>> GetAllAsync();       

        Task<Response<AppUserDto>> GetByIdAsync(string id);
    }
}
