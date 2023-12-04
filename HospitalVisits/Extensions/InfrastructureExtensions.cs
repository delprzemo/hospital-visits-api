using Application.Repository;
using Infrastructure.Database;
using Infrastructure.Repositories;
using System.Data.Entity;

namespace HospitalVisits.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("HospitalDb") ?? configuration["HospitalDb"];
            services.AddScoped(provider => new HospitalVisitsContext(connectionString));
            services.AddScoped<IHospitalRepository, HospitalRepository>();

            return services;
        }

        public static void InitializeDatabase(this WebApplication app)
        {
            var connectionString = app.Configuration.GetConnectionString("HospitalDb");
            Database.SetInitializer(new HospitalVisitsDbInit());

            using (var context = new HospitalVisitsContext(connectionString))
            {
                context.Database.Initialize(force: true);
            }
        }
    }


}
