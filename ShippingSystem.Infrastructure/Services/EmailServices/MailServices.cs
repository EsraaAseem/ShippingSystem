using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Domain.Share;

namespace ShippingSystem.Infrastructure.Services.EmailServices
{
    public class MailServices : IMailServices
    {
        private readonly SmtpSettings _settings;
        private readonly IStringLocalizer<MailServices> _localization;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MailServices(IOptions<SmtpSettings> settings, IStringLocalizer<MailServices> localization, IHttpContextAccessor httpContextAccessor)
        {
            _settings = settings.Value;
            _localization = localization;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task SendEmailAsync(string mailTo, string subject, string body, IList<IFormFile>? attachments = null)
        {
            var email = new MimeMessage()
            {
                Sender = MailboxAddress.Parse(_settings.Username),
                Subject = subject
            };
            email.To.Add(MailboxAddress.Parse(mailTo));

            var builder = new BodyBuilder();
            if (attachments is not null)
            {
                byte[] fileBytes;
                foreach (var file in attachments)
                {
                    if (file.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();

                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_settings.DisplayName, _settings.Username));

            try
            {
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_settings.Sender, _settings.Port);
                await smtp.AuthenticateAsync(_settings.Username, _settings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch
            {
                throw new BadHttpRequestException(_localization["errorInSendEmail"].Value);
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
        private string GenerateOtp()
        {
            var random = new Random();
            var otp = random.Next(1000, 9999).ToString();
            return otp;
        }
        public bool CheckOtp(string reciveOtp)
        {
            var otp = _httpContextAccessor.HttpContext.Request.Cookies["storeOtp"];
            if (otp != reciveOtp)
                return false;
            return true;
        }
        public string CallOtp()
        {
            var otp = GenerateOtp();
            SetOtpInCookie(otp);
            return otp;
        }
    
    }
}
