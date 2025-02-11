using Business.Mappings;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.ResponseTypes;
using Core.Roles;
using Core.Services;
using Core.UnitOfWorks;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Business.Servies.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService, IUnitOfWork unitOfWork, IUserRefreshTokenRepository userRefreshTokenRepository, ILogger<AuthenticationService> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _userRefreshTokenRepository = userRefreshTokenRepository;
            _logger = logger;
        }

        public async Task<Response<TokenDto>> CreateTokenForLoginAsync(UserForLoginDto userForLoginDto)
        {
            if (userForLoginDto == null)
                throw new ArgumentNullException(nameof(userForLoginDto));

            var user = await _userManager.FindByEmailAsync(userForLoginDto.Email);
            if (user == null)
            {
                _logger.LogError("Email or Password is wrong");
                return Response<TokenDto>.Fail("Email or Password is wrong", 400, true);
            }


            if (!await _userManager.CheckPasswordAsync(user, userForLoginDto.Password))
            {
                _logger.LogError("Email or Password is wrong");
                return Response<TokenDto>.Fail("Email or Password is wrong", 400, true);
            }

            var token = _tokenService.CreateToken(user);
                     
            var userRefreshToken = await _userRefreshTokenRepository.GetAsync(x => x.UserId == user.Id);

            if (userRefreshToken == null)
            {
                _userRefreshTokenRepository.Add(new UserRefreshToken
                {
                    UserId = user.Id,
                    Code = token.RefreshToken,
                    Expiration = token.RefreshTokenExpiration
                });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }

            await _unitOfWork.SaveChangesAsync();

            return Response<TokenDto>.Success(token, 200);
        }

        public async Task<Response<AppUserDto>> RegisterForUserAsync(CreateUserDto createUserDto)
        {
            var userExists = await _userManager.FindByEmailAsync(createUserDto.Email);
            if (userExists != null)
            {
                _logger.LogError($"The user is registered. => {createUserDto.Email}");
                return Response<AppUserDto>.Fail("The user is registered.", 400, true);
            }

            var user = new AppUser { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                _logger.LogError($"{errors}");

                return Response<AppUserDto>.Fail(new ErrorDto(errors, true), 400);
            }

            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            return Response<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), 200);
        }

        public async Task<Response<AppUserDto>> RegisterForAdminAsync(CreateUserDto createUserDto)
        {
            var userExists = await _userManager.FindByEmailAsync(createUserDto.Email);
            if (userExists != null)
                return Response<AppUserDto>.Fail("The user is registered.", 400, true);

            var user = new AppUser { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<AppUserDto>.Fail(new ErrorDto(errors, true), 400);
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Response<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), 200);
        }

        public async Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenRepository.GetAsync(x => x.Code == refreshToken);
            if (existRefreshToken == null)
                return Response<TokenDto>.Fail("Refresh token not found", 404, true);

            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);

            if (user == null)
                return Response<TokenDto>.Fail("User not found", 404, true);

            var tokenDto = _tokenService.CreateToken(user);

            existRefreshToken.Code = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;

            await _unitOfWork.SaveChangesAsync();

            return Response<TokenDto>.Success(tokenDto, 200);
        }

        public async Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenRepository.GetAsync(x => x.Code == refreshToken);

            if (existRefreshToken == null)
                return Response<NoDataDto>.Fail("Refresh token not found", 404, true);

            _userRefreshTokenRepository.Delete(existRefreshToken);

            await _unitOfWork.SaveChangesAsync();

            return Response<NoDataDto>.Success(200);
        }
    }
}
