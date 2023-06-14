using ConnectionPoint.Core.Domain.Entities;
using ConnectionPoint.Core.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionPoint.Taxing.Infrastructure.Persistence.EFCore
{
    public class TaxingRepository<TEntity> : EFCoreRepository<TEntity> where TEntity : FullAuditedEntityDto
    {
        public TaxingRepository(TaxingDbContext dbContext) : base (dbContext)
        {
                
        }
    }
}
