using Business.Mappings;
using Business.Servies.Abstract;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.ResponseTypes;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<Response<UpdateAppUserDto>> Update(UpdateAppUserDto updateAppUserDto)
        {
            var user = await _userManager.FindByIdAsync(updateAppUserDto.Id);
            if (user == null)
            {
                return Response<UpdateAppUserDto>.Fail("Id not found", 404, true);
            }


            user.UserName = updateAppUserDto.UserName;
            user.Status = updateAppUserDto.Status;
            await _userManager.UpdateAsync(user);

            return Response<UpdateAppUserDto>.Success(ObjectMapper.Mapper.Map<UpdateAppUserDto>(user), 204);

        }



    }
}
