using System.Reflection;
using ConnectionPoint.Core.Domain.Entities;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectionPoint.Core.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddModuleDatabaseContext<TDbContext>(this IServiceCollection services,
        IConfiguration configuration) where TDbContext : DbContext
    {
        Console.WriteLine($"the configurations is {configuration.GetConnectionString("Default")}");
        services.AddDbContext<TDbContext>(o => 
            o.UseNpgsql(configuration.GetConnectionString("Default"), 
                e => 
                    e.MigrationsAssembly(typeof(TDbContext).Assembly.FullName)));
        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();
        // dbContext.Database.Migrate();
        return services;
    }
    public static void RegisterRepositories(this IServiceCollection services, Type moduleRepository, Assembly assembly)
    {
        if (!moduleRepository.IsGenericTypeDefinition && moduleRepository.GetGenericTypeDefinition() != typeof(IRepository<>))
        {
            throw new ArgumentException(
                "The repository type must be a generic type definition, and must implement IRepository<> interface.",
                nameof(moduleRepository));
        }

        var entities = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(FullAuditedEntity)));
        
        foreach (var entity in entities)
        {
            services.AddScoped(typeof(IRepository<>).MakeGenericType(entity),
                moduleRepository.MakeGenericType(entity));
        }
    }
    
}
