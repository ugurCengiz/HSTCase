using Core.Configurations;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Business.Servies.Concrete
{
    public class TokenService : ITokenService
    {
        private readonly CustomTokenOption _customTokenOption;
        private readonly UserManager<AppUser> _userManager;

        public TokenService(IOptions<CustomTokenOption> options, UserManager<AppUser> userManager)
        {
            _customTokenOption = options.Value;
            _userManager = userManager;
        }

        public TokenDto CreateToken(AppUser appUser)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_customTokenOption.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_customTokenOption.RefreshTokenExpiration);

            var securityKey = SignService.GetSymmetricSecurityKey(_customTokenOption.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _customTokenOption.Issuer,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetClaims(appUser, _customTokenOption.Audience),
                signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDto
            {
                AccessToken = token,
                AccessTokenExpiration = accessTokenExpiration,
                RefreshToken = RandomRefreshToken(),
                RefreshTokenExpiration = refreshTokenExpiration
            };

            return tokenDto;
        }


        private string RandomRefreshToken()
        {
            byte[] numberByte = new Byte[32];

            using RandomNumberGenerator random = RandomNumberGenerator.Create();

            random.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }

        private IEnumerable<Claim> GetClaims(AppUser appUser, List<string> audiences)
        {
            var userRoles = _userManager.GetRolesAsync(appUser).Result;

            var userList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                new Claim(JwtRegisteredClaimNames.Email, appUser.Email),
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in userRoles)
            {
                userList.Add(new Claim(ClaimTypes.Role, userRole));
            }

            userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            return userList;
        }
    }
}
