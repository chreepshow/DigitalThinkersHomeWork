using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalThinkersHomeWork.Driver
{
    public static class DriverServiceConfigurationExtensions
    {
        public  static IServiceCollection AddDriverConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IDriverService, DriverService>();

            return services;
        }
    }
}
