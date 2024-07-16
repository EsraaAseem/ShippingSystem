using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions;
using ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.ConfirmAddClient;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.CompanyEmployee.ResponseClientAddRequest.RejectAddClient
{
    internal class RejectAddClientCommandHandler : ICommandHandler<RejectAddClientCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<AddClientResponseCommandHandler> _localization;
       
        public RejectAddClientCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<AddClientResponseCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
           
        }

        public async Task<BaseResponse> Handle(RejectAddClientCommand request, CancellationToken cancellationToken)
        {
            var clientRequest = await _unitOfWork.ClientAddRequestRepository.GetClientRequest(request.id);
            if (clientRequest == null)
                return await BaseResponse.NotFoundResponsAsync(_localization["clientNotFound"].Value);
          
            await _unitOfWork.ClientAddRequestRepository.Remove(clientRequest);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return await BaseResponse.SuccessResponseWithMessageAsync(_localization["RejectAddClient"].Value);
        }
    }
}
