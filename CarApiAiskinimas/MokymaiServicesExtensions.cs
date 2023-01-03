using CarApiAiskinimas.Repositories;
using CarApiAiskinimas.Services;

namespace CarApiAiskinimas
{
    public static class MokymaiServicesExtensions
    {
        public static IServiceCollection AddMokymaiServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ICarAdapter, CarAdapter>();
            services.AddTransient<ICarLeasingService, CarLeasingService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserCarRepository, UserCarRepository>();

            return services;
        }
    }
}
