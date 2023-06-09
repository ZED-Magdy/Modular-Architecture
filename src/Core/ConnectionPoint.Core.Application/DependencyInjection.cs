using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectionPoint.Core.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddACommonServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}