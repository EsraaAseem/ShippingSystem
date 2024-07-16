using ShippingSystem.Domain.Models;
using System.IdentityModel.Tokens.Jwt;


namespace ShippingSystem.Application.Abstractions.Interfaces
{
    public interface IJwtService
    {
        Task<JwtSecurityToken> GenerateToken(AppUser user);
        string GenerateRefreshToken();
    }
}
