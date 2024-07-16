using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShippingSystem.Application.Abstractions.Interfaces;
using ShippingSystem.Domain.IRepositories;
using ShippingSystem.Domain.Models;
using ShippingSystem.Presistance.Data;
using ShippingSystem.Presistance.Repostiories;
using ShippingSystem.Presistance.Services;


namespace ShippingSystem.Presistance.ExtensionService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddChatContext(configuration)
                    .AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddScoped<IAuthService, AuthService>();

            return services;
        }
        private static IServiceCollection AddChatContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShippingSystemContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            });
            services.AddIdentity<AppUser, IdentityRole>().AddDefaultTokenProviders()
             .AddEntityFrameworkStores<ShippingSystemContext>();
            services.Configure<IdentityOptions>(options =>
            {
                // Configure password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 1;

            });


            return services;
        }
    }
}
