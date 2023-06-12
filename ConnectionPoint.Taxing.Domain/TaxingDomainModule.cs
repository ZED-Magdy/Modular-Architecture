using Microsoft.Extensions.DependencyInjection;

namespace ConnectionPoint.Taxing.Domain
{
    public static class TaxingDomainModule
    {
        public static IServiceCollection AddTaxingDomainModule(this IServiceCollection services)
        {
            return services;
        }
    }
}