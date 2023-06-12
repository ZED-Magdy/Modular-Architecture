using ConnectionPoint.Voucher.Application.Services;
using ConnectionPoint.Voucher.Application.Services.Contracts;
using ConnectionPoint.Voucher.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectionPoint.Voucher.Application
{
    public static class VoucherApplicationModule
    {
        public static IServiceCollection AddAVoucherModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddVoucherInfrastructure(configuration);
            services.AddScoped(typeof(ICouponAppService), typeof(CouponAppService));
            services.AddAutoMapper(typeof(VoucherApplicationModule).Assembly);
            return services;
        }
    }
}
