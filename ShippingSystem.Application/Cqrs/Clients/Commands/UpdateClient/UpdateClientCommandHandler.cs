using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.Clients.Commands.UpdateClient
{
    internal class UpdateClientCommandHandler : ICommandHandler<UpdateClientCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaService _mediaService;
        private readonly IStringLocalizer<UpdateClientCommandHandler> _localization;
        public UpdateClientCommandHandler(IUnitOfWork unitOfWork, IMediaService mediaService, IStringLocalizer<UpdateClientCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _mediaService = mediaService;
            _localization = localization;
        }
        public async Task<BaseResponse> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientRepository.GetClientAsync(request.clientId);
            if (client is {})
                return await BaseResponse.NotFoundResponsAsync(_localization["NotFoundUser"].Value);
            if (request.email == null ||request.userName == null)
                return await BaseResponse.NotFoundResponsAsync(_localization["RequiredEmailAndUserName"].Value);
            string image = "";
            if (request.logo is not null)
            {
                if (client.Logo == null)
                    image=await _mediaService.UploadImageAsync(request.logo, "ClientImages");
                else image= await _mediaService.UpdateImageAsync(client.Logo, request.logo, "ClientImages");
            }
            client.UpdateClient(request.email, request.userName, request.phoneNumber, request.address, request.companyName,
                image, request.Covernorate, request.city, request.branch);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
                return await BaseResponse.SuccessResponseWithMessageAsync(_localization["UpdateClientSuccess"].Value);
        }
    }
}
/*
 
 client.Email = request.email;
            client.UserName = request.userName;
            client.NormalizedUserName = request.userName.ToUpper();
            client.NormalizedEmail = request.email.ToUpper();
            client.PhoneNumber = request.phoneNumber;
            client.Address=request.address;
            client.CompanyName = request.companyName;
            client.Logo = image;
            client.Governorate = request.Covernorate;
            client.City = request.city;
            client.Branch=request.branch;
 */
