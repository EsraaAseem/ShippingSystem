using Microsoft.AspNetCore.Identity;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Domain.Models;


namespace ShippingSystem.Presistance.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        public AuthService(UserManager<AppUser> userManager )
        {
            _userManager = userManager;
        }

        
       
    }
}
