using Microsoft.AspNetCore.Identity;
using ShippingSystem.Domain.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShippingSystem.Domain.Models
{
    public class AppUser:IdentityUser
    {
        private readonly List<RefreshToken> _refreshTokens = new();

        public string? City { get; internal set; }
        public string? Address { get; internal set; }
        public IReadOnlyCollection<RefreshToken> RefreshTokens=>_refreshTokens;
        public  RefreshToken createRefToken(string token,DateTime createOn,DateTime expirOn)
        {
            var refToken = RefreshToken.CreateRefToken(token, createOn, expirOn);
            _refreshTokens.Add(refToken);
            return refToken;
        }

    }
}
