using ConnectionPoint.Core.Infrastructure;
using ConnectionPoint.Voucher.Domain;
using ConnectionPoint.Voucher.Infrastructure.Persistence.EFCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectionPoint.Voucher.Infrastructure
{
    public static class VoucherInfrastructureModule
    {
        public static IServiceCollection AddVoucherInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
        {
            services
                .AddModuleDatabaseContext<VoucherDbContext>(configuration)
                .AddScoped<IVoucherDbContext>(provider => provider.GetService<VoucherDbContext>()!);
            services.RegisterRepositories(typeof(VoucherRepository<>), typeof(VoucherDomainModule).Assembly);

            return services;
        }
    }
}