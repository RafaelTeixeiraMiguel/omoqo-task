using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Application.Repositories;

namespace Application
{
    public static class DepedencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Context
            services.AddScoped<DbContext, DataContext>();

            // Repositories
            services.AddScoped<IShipRepository, ShipRepository>();
        }
    }
}
