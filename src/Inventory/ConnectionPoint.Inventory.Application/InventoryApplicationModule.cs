using ConnectionPoint.Inventory.Application.Services;
using ConnectionPoint.Inventory.Application.Services.Contracts;
using ConnectionPoint.Inventory.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectionPoint.Inventory.Application;

public static class InventoryApplicationModule
{
    public static IServiceCollection AddAInventoryModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInventoryInfrastructure(configuration);
        services.AddScoped(typeof(ICategoryAppService), typeof(CategoryAppService));
        services.AddScoped(typeof(IProductAppService), typeof(ProductAppService));
        services.AddScoped(typeof(IServiceAppService), typeof(ServiceAppService));
        services.AddScoped(typeof(IDealAppService), typeof(DealAppService));
        services.AddAutoMapper(typeof(InventoryApplicationModule).Assembly);
        return services;
    }
}