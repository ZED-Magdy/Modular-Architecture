using ConnectionPoint.Core.Infrastructure;
using ConnectionPoint.Inventory.Domain;
using ConnectionPoint.Inventory.Domain.Entities;
using ConnectionPoint.Inventory.Infrastructure.Persistence.EFCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectionPoint.Inventory.Infrastructure;

public static class InventoryInfrastructureModule
{
    public static IServiceCollection AddInventoryInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddModuleDatabaseContext<InventoryDbContext>(configuration)
            .AddScoped<IInventoryDbContext>(provider => provider.GetService<InventoryDbContext>()!);
            // services.AddScoped<IRepository<Category>, InventoryRepository<Category>>();
            services.RegisterRepositories(typeof(InventoryRepository<>), typeof(InventoryDomainModule).Assembly);
            
        return services;
    }
}