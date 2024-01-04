using Microsoft.AspNetCore.Http;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Utility;

namespace ShippingSystem.Service.AuthService
{
    public interface IAuthService
    {
        Task<BaseResponse> LoginAsync(LoginDto Input);
        Task<BaseResponse> RegisterAsync(RegisterDto Input);
        Task<BaseResponse> GetCurentUser();
        Task<BaseResponse> RefreshTokenAsync(TokenDto token);
        Task<BaseResponse> SendOtpEmailAsync(string userEmail);
        Task<BaseResponse> SendEmailAsync(string userEmail, string msg);
        Task<BaseResponse> LogoutAsync(TokenDto token);
        Task<BaseResponse> CompareOtpAsync(string reciveOtp);
        Task<BaseResponse> ConfirmEmailAsync(ConfirmEmailDto confirmEmailDto);
        Task<BaseResponse> ResetPasswordByEmailAsync(ResetPasswordDto resetPassword);
        Task<BaseResponse> ChangePasswordByEmailAsync(ChangePasswordDto changePassword);
        Task<BaseResponse> CreateRoleAsync(AddRole addRole);
        Task<BaseResponse> GetRolesAsync();
    }
}
