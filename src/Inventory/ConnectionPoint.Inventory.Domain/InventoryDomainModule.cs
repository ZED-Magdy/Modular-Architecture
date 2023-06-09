using Microsoft.Extensions.DependencyInjection;

namespace ConnectionPoint.Inventory.Domain;

public static class InventoryDomainModule
{
    public static IServiceCollection AddInventoryDomain(this IServiceCollection services)
    {
        return services;
    }
}