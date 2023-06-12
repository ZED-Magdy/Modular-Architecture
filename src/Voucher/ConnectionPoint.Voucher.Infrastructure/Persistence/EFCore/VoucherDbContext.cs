using ConnectionPoint.Core.Infrastructure.Persistence.EFCore;
using ConnectionPoint.Voucher.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectionPoint.Voucher.Infrastructure.Persistence.EFCore
{
    public class VoucherDbContext : ModuleDbContext, IVoucherDbContext
    {
        protected override string Schema => "voucher";
        public VoucherDbContext(DbContextOptions<VoucherDbContext> options):base(options)
        {
                
        }
        public DbSet<Coupon>? Coupons { get;set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
