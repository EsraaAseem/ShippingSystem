using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShippingSystem.Application.Behaviors;
using System;
using System.Reflection;
using System.Text;

namespace ShippingSystem.Application.ExtensionService
{
    public static class DependencyInjection
    {
       
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMapping().AddMediatr().AddPipline().AddValidatorPipline();
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);
            return services;
        }
        private static IServiceCollection AddMapping(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            services.AddScoped<IMapper, ServiceMapper>();

            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            return services;
        }
        private static IServiceCollection AddMediatr(this IServiceCollection services)
        {

            return services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        }

        private static IServiceCollection AddPipline(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        }
        private static IServiceCollection AddValidatorPipline(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        }
    }
}
