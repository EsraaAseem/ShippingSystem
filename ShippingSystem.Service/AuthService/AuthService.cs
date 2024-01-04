using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShippingSystem.Model.BaseModel;
using ShippingSystem.Model.DtoModel;
using ShippingSystem.Model.HelperModel;
using ShippingSystem.Service.Exceptions.RequestExceptions;
using ShippingSystem.Utility;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using System.Text;
using static System.Net.WebRequestMethods;
using ShippingSystem.Service.ImagesService;

namespace ShippingSystem.Service.AuthService
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JWT _jwt;
        private readonly IMapper _mapper;
        protected readonly BaseResponse _response;
        private readonly SmtpSettings _smtpSettings;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPhotoService _photo;
        public AuthService(UserManager<ApplicationUser>userManager,IOptions<JWT> jwt,IMapper mapper ,IHttpContextAccessor httpContextAccessor, 
            IOptions<SmtpSettings> smtpSettings, RoleManager<IdentityRole> roleManager,IPhotoService photo)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _httpContextAccessor = httpContextAccessor;
            _roleManager = roleManager;
            _photo = photo;
            _mapper = mapper;
            this._response = new();
            _smtpSettings = smtpSettings.Value;
            _roleManager=roleManager;
        }
        public async Task<BaseResponse> RegisterAsync(RegisterDto Input)
        {

            if (await _userManager.FindByEmailAsync(Input.Email) is not null)
            {
                throw new BadRequestException("this user Email is already Exsit");
            }
            if (await _userManager.FindByNameAsync(Input.UserName) is not null)
            {
                throw new BadRequestException("this user User is already Exsit");
            }
            var user = new ApplicationUser
            {
                Email = Input.Email,
                Name = Input.Name,
                City = Input.City,
                StreetAddress = Input.StreetAddress,
                PostalCode = Input.PostalCode,
                PhoneNumber = Input.PhoneNumber,
                UserName = Input.UserName,
            };
            if (Input.Role == "Client" || Input.Role == null)
            {
                Input.Logo =await _photo.UploadImageAsync(Input.Image);
                user = _mapper.Map<Client>(Input);
            }
            else if (Input.Role == "Courier")
            {
                user = _mapper.Map<Courier>(Input);
            }
           
            var result = await _userManager.CreateAsync(user, Input.Password);
            var role = Roles.Role_Client;
                if (!result.Succeeded)
                    throw new BadRequestException(result.Errors.ToString());

                if (Input.Role == null)
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, Input.Role);
                    role = Input.Role;
                }
                var jwtSecurityToken = await CreateToken(user);
                var refreshToken = GenerateRefreshToken();
                user.RefreshTokens?.Add(refreshToken);
                await _userManager.UpdateAsync(user);

                var userDto= new userDto
                {
                    Email = user.Email,
                    ExpiresOn = jwtSecurityToken.ValidTo,
                    isAuthenticated = true,
                    Role = role,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    UserName = user.UserName,
                    RefreshToken = refreshToken.Token,
                    RefreshTokenExpiration = refreshToken.ExpiresOn
                };
           _response.Result = userDto;
            _response.Message = "Register Success";
            return _response;
        }
        public async Task<BaseResponse> LoginAsync(LoginDto Input)
        {

            var user = await _userManager.FindByEmailAsync(Input.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, Input.Password))
            {
                throw new NotFoundException("there is not email or password");
            }
            var userdto = new userDto();

            var jwtSecurityToken = await CreateToken(user);
            var roles = await _userManager.GetRolesAsync(user);
            userdto.Email = user.Email;
            userdto.UserName = user.UserName;
            userdto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            userdto.isAuthenticated = true;
            userdto.ExpiresOn = jwtSecurityToken.ValidTo;
            userdto.Role = roles[0];
            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                userdto.RefreshToken = activeRefreshToken.Token;
                userdto.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                userdto.RefreshToken = refreshToken.Token;
                userdto.RefreshTokenExpiration = refreshToken.ExpiresOn;
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }
            _response.Result = userdto;
            _response.Message = "Login Success";
            return _response;
        }
        public async Task<BaseResponse> GetCurentUser()
        {
            var email = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            var jwtSecurityToken = await CreateToken(user);
            var roles = await _userManager.GetRolesAsync(user);
            var userDto= new userDto
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                isAuthenticated = true,
                ExpiresOn = jwtSecurityToken.ValidTo,
                Role = roles[0],
            };
            _response.Result = userDto;
            _response.Message = "Get User Success";
            return _response;
        } 
        public async Task<BaseResponse> RefreshTokenAsync(TokenDto token)
        {
            var user = await getUserByToken(token.RefToken);

            var revoke = await RevokeTokenAsync(token);
            if (!revoke)
            {
                throw new BadHttpRequestException("generate Refresh Token");
            }
            var roles = await _userManager.GetRolesAsync(user);

            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);
            var jwtSecurityToken = await CreateToken(user);
            var userdto = new userDto();
            userdto.Email = user.Email;
            userdto.UserName = user.UserName;
            userdto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            userdto.isAuthenticated = true;
            userdto.ExpiresOn = jwtSecurityToken.ValidTo;
            userdto.Role = roles[0];
            userdto.RefreshToken = newRefreshToken.Token;
            userdto.RefreshTokenExpiration = newRefreshToken.ExpiresOn;
            _response.Message = "refresh Token Created Success";
             _response.Result=userdto;
            return _response;
        }
      
        public async Task<BaseResponse> SendOtpEmailAsync(string userEmail)
        {
            string otp = await GenerateOtp();
            SetOtpInCookie(otp);
            await SendEmail(userEmail, otp);
            _response.Message ="Email Send Success";
            _response.Result = otp;
            return _response;
        }
        public async Task<BaseResponse> SendEmailAsync(string userEmail,string msg)
        {
            await SendEmail(userEmail, msg);
            _response.Message = "Email Send Success";
            _response.Result = msg;
            return _response;
        }
        public async Task<BaseResponse> LogoutAsync(TokenDto token)
        {
            var resaul = await this.RevokeTokenAsync(token);
            if (!resaul)
                throw new BadRequestException("logout Wrong");
            _response.Message = "Logout Success";
            return _response;
        
        }

        public async Task<BaseResponse> CompareOtpAsync(string reciveOtp)
        {
            var res = CheckOtp(reciveOtp);
            _response.Result = reciveOtp;
            _response.Message ="otp Same";
            return _response;
        }

        public async Task<BaseResponse> ConfirmEmailAsync(ConfirmEmailDto confirmEmailDto)
        {
            var user = await getUserByEmail(confirmEmailDto.Email);

            bool checkotp = CheckOtp(confirmEmailDto.RecOtp);
            if (!checkotp)
            {
                throw new BadRequestException("Confirm Email Error");
            }
            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);
            _response.Message ="Email Confirm Success";
            return _response;
        }

        public async Task<BaseResponse> ResetPasswordByEmailAsync(ResetPasswordDto resetPassword)
        {
            var user = await getUserByEmail(resetPassword.UserName);
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, resetPassword.NewPassword);
            if (!result.Succeeded)
                throw new BadRequestException("Reset Password");

            if (user.EmailConfirmed == false)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
            }
            _response.Message ="Password Changed";
            return _response;
        }

        public async Task<BaseResponse> ChangePasswordByEmailAsync(ChangePasswordDto changePassword)
        {
            var user = await getUserByToken(changePassword.RefToken);
            if (!await _userManager.CheckPasswordAsync(user, changePassword.OldPassword))
            {
                throw new BadRequestException("user Or password Not Correct");
            }
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, changePassword.NewPassword);
            if (!result.Succeeded)
                throw new BadRequestException("Reset Password fail");
               _response.Message ="Password Changed";
            return _response;
        }

        public async Task<BaseResponse> CreateRoleAsync(AddRole addRole)
        {
            if (await _roleManager.RoleExistsAsync(addRole.RoleName))
                throw new BadHttpRequestException("Role Already Exsit");
            var newRole = new IdentityRole(addRole.RoleName);
            var result = await _roleManager.CreateAsync(newRole);
            _response.Result = result;
            _response.Message ="Create OrgRole Success";
            return _response;
        }

        public async Task<BaseResponse> GetRolesAsync()
        {
            var Roles = _roleManager.Roles.Select(r => new { r.Id, r.Name }).ToList();
            _response.Result = Roles;
            _response.Message ="Get Roles Success";
            return _response;
        }
        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow
            };
        }
        private async Task<JwtSecurityToken> CreateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
        private async Task<bool> RevokeTokenAsync(TokenDto token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token.RefToken));

            if (user == null)
            {
                throw new NotFoundException("refresh Token Not Found");
            }
            var refreshToken = user.RefreshTokens.Single(t => t.Token == token.RefToken);

            if (!refreshToken.IsActive)
            {
                throw new UnauthorizedException("Unauthorized");
            }
            user.RefreshTokens.Remove(refreshToken);
            await _userManager.UpdateAsync(user);
            return true;
        }
        private bool CheckOtp(string reciveOtp)
        {
            // var user = await getUserAsync(phone);
            var otp = _httpContextAccessor.HttpContext.Request.Cookies["storeOtp"];
            if (otp != reciveOtp)
            {
                throw new BadRequestException("otp Wrong");
            }
            return true;
        }
        private async Task<string> GenerateOtp()
        {
            var random = new Random();
            var otp = random.Next(100000, 999999).ToString();
            return otp;
        }
        private async Task<ApplicationUser> getUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new NotFoundException("Email Not Found");
            return user;
        }
        private async Task<ApplicationUser> getUserByToken(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));
            if (user == null)
                throw new NotFoundException("refresh Token Not Found");
            return user;
        }
        private async Task<bool> SendEmail(string userEmail, string mail)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_smtpSettings.Sender));
                email.To.Add(MailboxAddress.Parse(userEmail));
                email.Subject = "Your OTP";
                email.Body = new TextPart(TextFormat.Plain) { Text = "Your OTP is: " + mail };
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_smtpSettings.Sender, _smtpSettings.Port);
                await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
                return true;
            }
            catch (Exception)
            {
                throw new BadHttpRequestException("error In Send Email");
            }
        }
     
        private void SetOtpInCookie(string otp)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddMinutes(60),
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append("storeOtp", otp, cookieOptions);
        }
      /*  public async Task <string> Image(IFormFile formFile)
        {
             var photo=_photo.UploadImageAsync(formFile);
            return photo.Result;
        }*/
  
    }
}
