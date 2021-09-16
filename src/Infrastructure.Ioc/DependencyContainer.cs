using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            InitializeApplication(services);
            InitializeDomain(services);
        }

        private static void InitializeApplication(IServiceCollection services)
        {
            services.AddTransient<IWeatherForecastService, WeatherForecastService>();
        }

        private static void InitializeDomain(IServiceCollection services)
        {
            services.AddTransient<IWeatherRepository, WeatherRepository>();
        }
    }
}
