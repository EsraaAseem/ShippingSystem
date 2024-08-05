using ShippingSystem.Application.Abstractions;
using ShippingSystem.Shared;


namespace ShippingSystem.Application.Cqrs.AccountManagment.ResetPassword
{
    public record ResetPasswordCommand(string email,string oldPassword,string newPassword) : ICommand<BaseResponse>;
   
}
