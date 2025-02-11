using Business.Mappings;
using Business.Servies.Abstract;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.ResponseTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Servies.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<IEnumerable<AppUserDto>>> GetAllAsync()
        {
            var results = ObjectMapper.Mapper.Map<List<AppUserDto>>(await _userManager.Users.ToListAsync());

            return Response<IEnumerable<AppUserDto>>.Success(results, 200);
        }

        public async Task<Response<AppUserDto>> GetByIdAsync(string id)
        {
            var result = await _userManager.FindByIdAsync(id);

            if (result == null)
            {
                return Response<AppUserDto>.Fail("Id not found", 404, true);
            }

            return Response<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(result), 200);
        }

    }
}
