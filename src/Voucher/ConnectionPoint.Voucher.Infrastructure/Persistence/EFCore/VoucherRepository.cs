using ConnectionPoint.Core.Domain.Entities;
using ConnectionPoint.Core.Infrastructure.Persistence;

namespace ConnectionPoint.Voucher.Infrastructure.Persistence.EFCore
{
    public class VoucherRepository<TEntity> : EFCoreRepository<TEntity> where TEntity : FullAuditedEntity
    {
        public VoucherRepository(VoucherDbContext dbContext) : base(dbContext)
        {
        }
    }
}
