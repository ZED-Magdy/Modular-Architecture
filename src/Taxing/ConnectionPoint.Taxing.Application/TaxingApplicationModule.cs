using ConnectionPoint.Taxing.Application.Services;
using ConnectionPoint.Taxing.Application.Services.Contracts;
using ConnectionPoint.Taxing.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectionPoint.Taxing.Application
{
    public static class TaxingApplicationModule
    {
        public static IServiceCollection AddATaxingModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTaxingInfrastructure(configuration);
            services.AddScoped(typeof(ITaxAppService), typeof(TaxAppService));
            services.AddScoped(typeof(ITaxableAppService), typeof(TaxableAppService));
            services.AddAutoMapper(typeof(TaxingApplicationModule).Assembly);
            return services;
        }
    }
}