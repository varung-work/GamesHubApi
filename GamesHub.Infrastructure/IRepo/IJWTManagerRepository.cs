using GamesHub.Model.UtilityModel;
using GamesHUb.Domain.Entity;
using System.Security.Claims;

namespace GamesHub.Infrastructure.IRepo
{
    public interface IJWTManagerRepository
    {
        TokenModel GenerateToken(User user);
        TokenModel GenerateRefreshToken(User user);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
