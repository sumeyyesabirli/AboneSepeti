using Abonesepeti.Bussines.RequestModel;
using Abonesepeti.Core.ResponseManager;
using System.Security.Claims;

namespace Abonesepeti.Bussines.Abstract
{
    public interface IJwtService
    {
        Task<TokenResponseModel> GenerateTokensAsync(UserRequestModel user);
        string GenerateAccessToken(UserRequestModel user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        Task<TokenResponseModel> RefreshTokenAsync(string accessToken, string refreshToken);
    }
}
