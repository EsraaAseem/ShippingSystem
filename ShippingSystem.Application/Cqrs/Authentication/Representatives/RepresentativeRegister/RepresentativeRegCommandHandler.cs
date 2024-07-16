using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.ShareResponse.AuthResponse;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.ConfirmAddClient;

namespace ShippingSystem.Application.Cqrs.Authentication.Representatives.RepresentativeRegister
{
    internal class RepresentativeRegCommandHandler : ICommandHandler<RepresentativeRegCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<AddClientResponseCommandHandler> _localization;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public RepresentativeRegCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<AddClientResponseCommandHandler> localization,
            UserManager<AppUser> userManager, IMapper mapper, IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
            _userManager = userManager;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<BaseResponse> Handle(RepresentativeRegCommand request, CancellationToken cancellationToken)
        {

            if (request.email == null && request.phoneNumber == null)
                return await BaseResponse.BadRequestResponsAsync(_localization["phoneOremailRequired"].Value);

            if (request.phoneNumber is not null)
                if (await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.phoneNumber) is not null)
                    return await BaseResponse.BadRequestResponsAsync(_localization["phoneNumberExist"].Value);

            if (request.email is not null)
                if (await _userManager.FindByEmailAsync(request.email) is not null)
                    return await BaseResponse.BadRequestResponsAsync(_localization["EmailExist"].Value);

            if (await _userManager.FindByNameAsync(request.userName) is not null)
            {
                return await BaseResponse.BadRequestResponsAsync(_localization["userNameExist"].Value);
            }
            var representative = Representative.CreateRepresentative(request.firstName, request.lastName, request.Covernorate
                , request.branch, request.phoneNumber, request.email, request.userName,request.city,request.address);
            var result = await _userManager.CreateAsync(representative, request.password);
            if (!result.Succeeded)
            {
                return await BaseResponse.BadRequestResponsAsync(_localization["ErrorOnAddUser"].Value);
            }
            var roleResult = await _userManager.AddToRoleAsync(representative, Roles.Role_Representative);
            if (!roleResult.Succeeded)
                return await BaseResponse.NotFoundResponsAsync(_localization["ErrorInAddRole"].Value);
            var jwtToken = await _jwtService.GenerateToken(representative);
            var refToken = _jwtService.GenerateRefreshToken();
            var refreshToken = representative.createRefToken(refToken, DateTime.UtcNow, DateTime.UtcNow.AddDays(20));
            var response = _mapper.Map<RepresentativeAuthResponse>(representative);
            response.TokensData.TokenExpiryDate = jwtToken.ValidTo;
            response.TokensData.RefTokenExpiryDate = refreshToken.ExpiresOn;
            response.TokensData.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            response.TokensData.RefreshToken = refToken;
            response.IsAuthenticated = true;
            response.Role=Roles.Role_Representative;
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return await BaseResponse.SuccessResponseWithDataAsync(response);

        }
    }
}
