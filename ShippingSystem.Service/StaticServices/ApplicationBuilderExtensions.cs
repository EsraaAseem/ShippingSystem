using Microsoft.AspNetCore.Builder;
using ShippingSystem.Service.Exceptions.ExceptionsMiddleWare;

namespace ShippingSystem.Service.StaticServices
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalExceptionGlobalHandler(this IApplicationBuilder app)
         => app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
    }
}
