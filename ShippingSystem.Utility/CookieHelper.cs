using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingSystem.Utility
{
    public static class CookieHelper
    {
        public static void SetRefreshTokenInCookie(string refreshToken, DateTime expires, HttpResponse response)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime(),
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None
            };

            response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
