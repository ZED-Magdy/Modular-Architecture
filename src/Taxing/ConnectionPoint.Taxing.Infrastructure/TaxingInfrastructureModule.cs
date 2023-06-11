using ConnectionPoint.Core.Infrastructure;
using ConnectionPoint.Taxing.Domain;
using ConnectionPoint.Taxing.Infrastructure.Persistence.EFCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectionPoint.Taxing.Infrastructure
{
    public static class TaxingInfrastructureModule
    {
        public static IServiceCollection AddTaxingInfrastructure(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddModuleDatabaseContext<TaxingDbContext>(configuration);
            services.AddScoped<ITaxingDbContext>(provider => provider.GetService<TaxingDbContext>()!);
            services.RegisterRepositories(typeof(TaxingRepository<>), typeof(TaxingDomainModule).Assembly);
            return services;
        }
    }
}