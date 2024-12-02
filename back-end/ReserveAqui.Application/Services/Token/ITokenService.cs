using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace ReserveAqui.Application.Services.Token
{
    internal interface ITokenService
    {
        JwtSecurityToken GenerateAcessToken(IEnumerable<Claim> claims,
        IConfiguration _config);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token,
            IConfiguration _config);
    }
}
