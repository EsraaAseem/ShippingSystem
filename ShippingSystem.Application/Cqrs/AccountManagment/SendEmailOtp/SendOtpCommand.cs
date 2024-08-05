using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.AccountManagment.SendEmailOtp;

    public record SendOtpCommand(string userEmail):ICommand<BaseResponse>;

