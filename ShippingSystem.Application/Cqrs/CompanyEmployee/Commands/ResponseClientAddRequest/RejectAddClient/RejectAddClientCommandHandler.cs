using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.ConfirmAddClient;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;
using static System.Net.WebRequestMethods;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.RejectAddClient
{
    internal class RejectAddClientCommandHandler : ICommandHandler<RejectAddClientCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<RejectAddClientCommandHandler> _localization;
       private readonly IMailServices _mailService;
        public RejectAddClientCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<RejectAddClientCommandHandler> localization
            , IMailServices mailService)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
            _mailService = mailService;
        }

        public async Task<BaseResponse> Handle(RejectAddClientCommand request, CancellationToken cancellationToken)
        {
            var clientRequest = await _unitOfWork.ClientAddRequestRepository.GetClientRequest(request.id);
            if (clientRequest == null)
                return await BaseResponse.NotFoundResponsAsync(_localization["clientNotFound"].Value);
          
            await _unitOfWork.ClientAddRequestRepository.Remove(clientRequest);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (_mailService != null)
            {

                await _mailService.SendEmailAsync(
                                mailTo: clientRequest.Email,
                subject: "Account Create Response",
                                body: "Your Create Account Request  Rejected Confirm Connect to the System to Know the Problem please");

            }
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["RejectAddClient"].Value);
        }
    }
}
