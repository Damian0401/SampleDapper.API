using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Persistance.DataAccess;
using Persistance.DataAccess.Interfaces;
using Persistance.DataAccess.Repositories;

namespace Application.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            // DataContext
            services.AddSingleton<DataContext>();

            // Repositories
            services.AddTransient<IPersonRepository, PersonRepository>();

            // Services
            services.AddTransient<IPersonService, PersonService>();
        }
    }
}
