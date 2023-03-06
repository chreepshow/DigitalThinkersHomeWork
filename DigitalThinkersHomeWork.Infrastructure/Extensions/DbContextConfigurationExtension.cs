using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalThinkersHomeWork.Infrastructure
{
    public static class DbContextConfigurationExtension
    {
        public static IServiceCollection AddDriverDbContextConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IDriverDbContext, DriverDbContext>();

            return services;
        }
    }
}
