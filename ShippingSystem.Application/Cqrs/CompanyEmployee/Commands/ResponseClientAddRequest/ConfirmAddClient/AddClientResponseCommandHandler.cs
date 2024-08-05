using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Application.Cqrs.CompanyEmployee.Commands.ResponseClientAddRequest.ConfirmAddClient;
using ShippingSystem.Application.Cqrs.ShareResponse.AuthResponse;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;
using System.IdentityModel.Tokens.Jwt;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.ConfirmAddClient
{
    internal class AddClientResponseCommandHandler : ICommandHandler<AddClientResponseCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<AddClientResponseCommandHandler> _localization;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        private readonly IMailServices _mailService;
        public AddClientResponseCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<AddClientResponseCommandHandler> localization,
            UserManager<AppUser> userManager,IMapper mapper,IJwtService jwtService,IMailServices mailService)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
            _userManager = userManager;
            _mapper = mapper;
            _jwtService = jwtService;
            _mailService = mailService;
        }

        public async Task<BaseResponse> Handle(AddClientResponseCommand request, CancellationToken cancellationToken)
        {
            var clientRequest = await _unitOfWork.ClientAddRequestRepository.GetClientRequest(request.id);
            if (clientRequest == null)
               return await BaseResponse.NotFoundResponsAsync(_localization["clientNotFound"].Value);
            var client = _mapper.Map<Client>(clientRequest);
            var result = await _userManager.CreateAsync(client,clientRequest.Password);
            if (!result.Succeeded)
            {
                return await BaseResponse.BadRequestResponsAsync(_localization["ErrorOnAddUser"].Value);
            }
            var roleResult = await _userManager.AddToRoleAsync(client, Roles.Role_Client);
            if (!roleResult.Succeeded)
                return await BaseResponse.NotFoundResponsAsync(_localization["ErrorInAddRole"].Value);
            var jwtToken = await _jwtService.GenerateToken(client);
            var refToken = _jwtService.GenerateRefreshToken();
            var refreshToken = client.createRefToken(refToken, DateTime.UtcNow, DateTime.UtcNow.AddDays(20));
            var response = _mapper.Map<ClientAuthResponse>(client);
            response.TokensData.TokenExpiryDate = jwtToken.ValidTo;
            response.TokensData.RefTokenExpiryDate = refreshToken.ExpiresOn;
            response.TokensData.Token= new JwtSecurityTokenHandler().WriteToken(jwtToken);
            response.TokensData.RefreshToken = refToken;
            response.IsAuthenticated = true;
            await _unitOfWork.ClientAddRequestRepository.Remove(clientRequest);
           await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (_mailService != null)
            {

                await _mailService.SendEmailAsync(
                                mailTo: clientRequest.Email,
                subject: "Account Create Response",
                                body: "Your Account Confirm Success");

            }
            return await BaseResponse.SuccessResponseWithDataAsync(response);

        }
    }
}
