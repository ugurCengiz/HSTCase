using Core.Entities.DTOs;
using Core.ResponseTypes;
using Entities.Concrete;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Servies.Abstract
{
    public interface IUserService
    {
        Task<Response<UpdateAppUserDto>> Update(UpdateAppUserDto updateAppUserDto);
        Task<Response<IEnumerable<AppUserDto>>> GetAllAsync();       

        Task<Response<AppUserDto>> GetByIdAsync(string id);
        
    }
}
