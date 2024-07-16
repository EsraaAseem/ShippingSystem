using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Domain.Enums;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace ShippingSystem.Application.Cqrs.Authentication.Client.ClientRegister
{
    internal class ClientRegCommandHandler : ICommandHandler<ClientRegCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediaService _mediaService;
        private readonly IStringLocalizer<ClientRegCommandHandler> _localization;
        public ClientRegCommandHandler(IUnitOfWork unitOfWork, IMediaService mediaService, IStringLocalizer<ClientRegCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _mediaService = mediaService;
            _localization = localization;
        }

        public async Task<BaseResponse> Handle(ClientRegCommand command, CancellationToken cancellationToken)
        {
            var clientCheck =  _unitOfWork.ClientAddRequestRepository.CheckClientRequestEmail(command.email);
            var clientCheckUserName = _unitOfWork.ClientAddRequestRepository.CheckClientRequestUserName(command.userName);
            if (clientCheck || clientCheckUserName)
                return await BaseResponse.BadRequestResponsAsync(_localization["EmailOrUserNameExist"].Value);
            var imgUrl = await _mediaService.UploadImageAsync(command.logo, "ClientImages");
          var clientRequest = ClientAddRequest.CreateClientAddRequest(Guid.NewGuid(), command.email, command.userName, command.password, command.name,
           command.phoneNumber, command.address, command.companyName,imgUrl, command.Covernorate, command.city, command.branch);
           var clientRequestRepo =  _unitOfWork.ClientAddRequestRepository.Add(clientRequest);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            Notification.CreateNotifaction(Guid.NewGuid(), null, clientRequest.Name, clientRequest.Logo,
                _localization["AddClientRequestTitle"].Value,
                 _localization["AddClientRequestDescription"].Value.Replace("Name", $"{clientRequest.Name}"),
                NotificationType.AddClientRequest,false, DateTime.UtcNow);
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["CreateRequestClientSuccess"].Value);
        }
    }
}
