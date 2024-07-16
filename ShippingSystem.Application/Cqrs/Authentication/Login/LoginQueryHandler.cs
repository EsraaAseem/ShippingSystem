using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Application.Cqrs.ShareResponse.AuthResponse;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;
using System.ComponentModel.Design;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;

namespace ShippingSystem.Application.Cqrs.Authentication.Login
{
    internal class LoginQueryHandler : IQueryHandler<LoginQuery, BaseResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<LoginQueryHandler> _localization;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public LoginQueryHandler(IUnitOfWork unitOfWork, IStringLocalizer<LoginQueryHandler> localization,
            UserManager<AppUser> userManager, IMapper mapper, IJwtService jwtService, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
            _userManager = userManager;
            _mapper = mapper;
            _jwtService = jwtService;
            _roleManager = roleManager;
        }
        public async Task<BaseResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            const string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            const string phonePattern = @"^(?:\+?20)?(?:0)?1[0-2]\d{8}$";
            AppUser user = null;
            if (Regex.IsMatch(request.useName, emailPattern))
            {
               user= _userManager.FindByEmailAsync(request.useName).Result;
                if (user == null)
                    return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundEmail"].Value);
            }
            else if(Regex.IsMatch( request.useName,phonePattern))
            {
                user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber==request.useName );
                if (user == null)
                    return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundPhone"].Value);
            }
            else
            {
                user = await _userManager.FindByNameAsync(request.useName);
                if (user == null)
                    return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundUserName"].Value);
            }
            if (!await _userManager.CheckPasswordAsync(user, request.password))
            {
                return await BaseResponse.BadRequestResponsAsync(_localization["WrongPassword"].Value);
            }
            var role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();

            var jwtToken = await _jwtService.GenerateToken(user);
            var refToken = _jwtService.GenerateRefreshToken();
            var refreshToken = user.createRefToken(refToken, DateTime.UtcNow, DateTime.UtcNow.AddDays(20));
            DataAuthResponse response = null;
            if (role == Roles.Role_Client)
            response = _mapper.Map<ClientAuthResponse>(user);
           
            else if (role==Roles.Role_Representative)
           response = _mapper.Map<ClientAuthResponse>(user);
            else
            {
                response = _mapper.Map<EmployeeAuthResponse>(user);
                var rolePermission = await _roleManager.FindByNameAsync(role!);
                response.Permissions = _roleManager.GetClaimsAsync(rolePermission!).Result.Select(c => c.Value).ToList();
            }
            response.TokensData.TokenExpiryDate = jwtToken.ValidTo;
            response.TokensData.RefTokenExpiryDate = refreshToken.ExpiresOn;
            response.TokensData.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            response.TokensData.RefreshToken = refToken;
            response.Role =role;
            response.IsAuthenticated = true;
            return await BaseResponse.SuccessResponseWithDataAsync(response);
        }
    }
}
