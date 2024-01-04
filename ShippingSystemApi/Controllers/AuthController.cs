using Microsoft.AspNetCore.Mvc;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Service.AuthService;
using Microsoft.AspNetCore.Authorization;

namespace ShippingSystemApi.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authservice; 
        public AuthController(IAuthService authService)
        {
            _authservice = authService;
        }
     
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result = await _authservice.LoginAsync(model);
            return Ok(result);
        }

        [HttpGet("GetCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _authservice.GetCurentUser();
            return Ok(user);
        }
        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshToken(TokenDto tokenDto)
        {
            var result = await _authservice.RefreshTokenAsync(tokenDto);
            return Ok(result);
        }

        [HttpPost("logout")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Logout(TokenDto token)
        {
            var resault = await _authservice.LogoutAsync(token);
            return Ok(resault);
        }
        [HttpGet]
        [Route("sendEmail/{email}")]
        public async Task<IActionResult> SendEmail([FromRoute] string email)
        {
            var messag = await _authservice.SendOtpEmailAsync(email);
            return Ok(messag);
        }
        [HttpGet]//("compareOtp")]
        [Route("compareOtp/{recOtp}")]
        public async Task<IActionResult> CompareOtp([FromRoute] string recOtp)
        {
            
            var res = await _authservice.CompareOtpAsync(recOtp);
            return Ok(res);
        }
        [HttpPut("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailDto confirmEmail)
        {
            var resualt = await _authservice.ConfirmEmailAsync(confirmEmail);
            return Ok(resualt);
        }
        [HttpPost("resetPasswordByEmail")]
        public async Task<IActionResult> ResetPasswordByEmail([FromBody] ResetPasswordDto resetPassword)
        {
            var resualt = await _authservice.ResetPasswordByEmailAsync(resetPassword);

            return Ok(resualt);
        }
        [HttpPost("changePasswordByEmail")]
        public async Task<IActionResult> ChangePasswordByEmail([FromBody] ChangePasswordDto changePassword)
        {
            var resualt = await _authservice.ChangePasswordByEmailAsync(changePassword);
            return Ok(resualt);
        }
        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(AddRole addRole)
        {
            var res = await _authservice.CreateRoleAsync(addRole);
            return Ok(res);
        }
        [HttpGet("getRoles")]
        public async Task<IActionResult> GetOrgRoles()
        {
            return Ok(await _authservice.GetRolesAsync());
        }
    }
}
