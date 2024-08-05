

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Application.Abstractions.Interfaces.IServices;
using ShippingSystem.Infrastructure.Services.AuthService;
using ShippingSystem.Infrastructure.Services.BarCode;
using ShippingSystem.Infrastructure.Services.EmailServices;
using ShippingSystem.Infrastructure.Services.MediaService;
using System.Globalization;
using Wasla.Services.HlepServices.MultLanguageService.JsonLocalizer;

namespace ShippingSystem.Infrastructure.ExtensionService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddLocalization()
                .AddScoped<IMediaService, MediaService>()
            .AddScoped<IJwtService, JwtService>()
            .AddScoped<IMailServices, MailServices>()
            .AddScoped<IQrCode, QrCodes>();

            return services;
        }
        private static IServiceCollection AddLocalization(this IServiceCollection services)
        {
            LocalizationServiceCollectionExtensions.AddLocalization(services);


            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

            services.AddMvc().AddDataAnnotationsLocalization(op =>
            {
                op.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(JsonStringLocalizerFactory));
            }
             );

            services.Configure<RequestLocalizationOptions>(op =>
            {
                var supportedCultures = new[] {
                  new CultureInfo("en-US"),
                  new CultureInfo("ar-EG"),
                 };
                op.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0]);

                op.SupportedCultures = supportedCultures;
            });

            return services;

            /*  services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
             services.AddLocalization();

             services.Configure<RequestLocalizationOptions>(options =>
              {
                  var supportedCultures = new[]
                  {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar-EG"),
                  };

                  options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0]);
                  options.SupportedCultures = supportedCultures;
              });

             /* services.AddMvc().AddDataAnnotationsLocalization(op =>
              {
                  op.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(JsonStringLocalizerFactory));
              }
                  */
           // return services;
        }
    }
}
