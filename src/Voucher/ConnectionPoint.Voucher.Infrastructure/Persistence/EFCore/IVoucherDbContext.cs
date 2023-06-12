using ConnectionPoint.Voucher.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectionPoint.Voucher.Infrastructure.Persistence.EFCore
{
    public interface IVoucherDbContext
    {
        public DbSet<Coupon>? Coupons { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
